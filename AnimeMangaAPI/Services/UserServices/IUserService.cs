using AnimeMangaAPI.Models;

namespace AnimeMangaAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<string> CreateUser(Register user);
        Task<(Login?, string)> CheckUser(Login userDetails);

    }
}
