using AnimeMangaAPI.Models;
using AnimeMangaAPI.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeMangaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser ([FromBody]Register user)
        {

            return Ok(await _userService.CreateUser(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> CheckUser([FromBody]Login userDetails)
        {
            return Ok(await _userService.CheckUser(userDetails));
        }
    }
}
