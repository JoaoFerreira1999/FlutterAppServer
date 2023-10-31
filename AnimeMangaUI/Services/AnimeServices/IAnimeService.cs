using AnimeMangaUI.Models;

namespace AnimeMangaAPI.Services.AnimeServices
{
    public interface IAnimeService
    {
        Task<Root?> GetSingleAnime(string Name);
        List<Root> GetAllAnimes();

    }
}
