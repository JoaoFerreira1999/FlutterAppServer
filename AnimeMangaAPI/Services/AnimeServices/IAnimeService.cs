using AnimeMangaAPI.Models;

namespace AnimeMangaAPI.Services.AnimeServices
{
    public interface IAnimeService
    {
        Task<Datum?> GetSingleAnime(string Name);
        Task<List<Root>> GetAllAnimes();
        Task<List<Datum>?> GetTopAnime();
        Task<List<Favorites>> GetFavorites();
        Task<List<Datum>> GetAiringAnime();
        Task<List<RecommendationDatum>> GetAnimeRecommendations();
    }
}
