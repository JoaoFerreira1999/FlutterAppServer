using AnimeMangaAPI.Models;
using AnimeMangaAPI.Services.AnimeServices;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllAnimes()
        {
            return Ok(await _animeService.GetAllAnimes());
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetSingleAnime(string Name)
        {
            return Ok(await _animeService.GetSingleAnime(Name));
        }

        [HttpGet("/topAnimes")]
        public async Task<IActionResult> GetTopAnime()
        {
            return Ok(await _animeService.GetTopAnime());
        }

        [HttpGet("/favorites"), Authorize]
        public async Task<IActionResult> GetFavorites()
        {
            return Ok(await _animeService.GetFavorites());
        }

        [HttpGet("/airing")]
        public async Task<IActionResult> GetAiringAnime()
        {
            return Ok(await _animeService.GetAiringAnime());
        }

        [HttpGet("/recommendations")]
        public async Task<IActionResult> GetAnimeRecommendations()
        {
            return Ok(await _animeService.GetAnimeRecommendations());
        }
    }
}
