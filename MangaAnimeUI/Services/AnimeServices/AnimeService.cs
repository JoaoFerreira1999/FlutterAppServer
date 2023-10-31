using AnimeMangaAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace AnimeMangaAPI.Services.AnimeServices
{
    public class AnimeService : IAnimeService
    {
        private static readonly HttpClient client = new HttpClient();

        public List<Root> GetAllAnimes()
        {
            throw new NotImplementedException();
        }

        public async Task<Root?> GetSingleAnime(string Name)
        {
            var url = "https://api.jikan.moe/v4/anime?q=" + Name;
            var httpResponseMessage = await client.GetAsync(url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResponse);

            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonResponse);

            return myDeserializedClass;

        }
    }
}
