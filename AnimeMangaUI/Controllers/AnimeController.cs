using AnimeMangaAPI.Models;
using AnimeMangaAPI.Services.AnimeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeMangaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;
        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public IActionResult GetAllAnimes()
        {
            return Ok(_animeService.GetAllAnimes());
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetSingleAnime(string Name)
        {
            return Ok(await _animeService.GetSingleAnime(Name));
        }
    }
}
