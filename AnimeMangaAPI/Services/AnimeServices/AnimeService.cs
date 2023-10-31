using AnimeMangaAPI.Models;
using Newtonsoft.Json;


namespace AnimeMangaAPI.Services.AnimeServices
{
    public class AnimeService : IAnimeService
    {
        private static readonly HttpClient client = new HttpClient();

        public Task<List<Root>> GetAllAnimes()
        {
            throw new NotImplementedException();
        }

        public async Task<Datum?> GetSingleAnime(string Name)
        {
            var url = "https://api.jikan.moe/v4/anime?q=" + Name;
            var httpResponseMessage = await client.GetAsync(url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResponse);

            var myDeserializedClass = JsonConvert.DeserializeObject<Datum>(jsonResponse);

            return myDeserializedClass;

        }

        public async Task<List<Datum>?> GetTopAnime()
        {
            var url = "https://api.jikan.moe/v4/anime?min_score=9&limit=10";
            var httpResponseMessage = await client.GetAsync(url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonResponse);

            return myDeserializedClass?.data;
        }

        public async Task<List<Favorites>> GetFavorites()
        {
            Console.WriteLine("Here");
            return null;
        }

        public async Task<List<Datum>> GetAiringAnime()
        {
            var url = "https://api.jikan.moe/v4/seasons/now?limit=7";
            var httpResponseMessage = await client.GetAsync(url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonResponse);

            return myDeserializedClass!.data;

        }
        public async Task<List<RecommendationDatum>> GetAnimeRecommendations()
        {
            var url = "https://api.jikan.moe/v4/recommendations/anime";
            var httpResponseMessage = await client.GetAsync(url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            var myDeserializedClass = JsonConvert.DeserializeObject<RecommendationRoot>(jsonResponse);

            return myDeserializedClass!.data;

        }

    }
}
