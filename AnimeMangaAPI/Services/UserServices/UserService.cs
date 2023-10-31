using AnimeMangaAPI.Data;
using AnimeMangaAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AnimeMangaAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> CreateUser(Register user)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if(existingUser != null)
            {
                return ("User Already Exists!");
            }

            user.Password = passwordHash;
            _context.Users.Add(user);
            var createUserResult = await _context.SaveChangesAsync();

            if (createUserResult == 0)
            {
                return ("Failed to create user!");
            }

            return "User Successfully created!";     
        }

        public async Task<(UserDto?, string)> CheckUser(Login userDetails)
        {

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDetails.Email);

            if(existingUser == null)
            {
                return (null, "User with this email doesn't exist!");
            }

            if(!BCrypt.Net.BCrypt.Verify(userDetails.Password, existingUser.Password))
            {
                return (null, "Password does not match!");
            }

            UserDto user = new UserDto();
            user.Username = existingUser.Name;
            user.Email = existingUser.Email;
            user.Favorites = existingUser.Favorites;

            string token = CreateToken(user);

            return (user, token);
        }


        private string CreateToken(UserDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
