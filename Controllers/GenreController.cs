using LibraryTask.Models;
using LibraryTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<Genre>> GetGenres()
        {
            return Ok(await _genreService.GetAll());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            return Ok(await _genreService.GetByID(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Genre>> AddGenre(Genre genre)
        {
            return Ok(await _genreService.Add(genre));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, Genre genre)
        {
            return Ok(await _genreService.Update(genre, id));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id, Genre genre)
        {
            return Ok(await _genreService.Delete(id, genre));
        }
    }
}
