using LibraryTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryTask.Models;

namespace LibraryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<Author>> GetAuthors()
        {
            return Ok(await _authorService.GetAll());
        }

        [HttpGet("Get by id")]
        public async Task<ActionResult<Author>> GetAuthor(int id )
        {
            return Ok(await _authorService.GetByID(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            return Ok(await _authorService.Add(author));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, Author author)
        {
            return Ok(await _authorService.Update(author, id));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id, Author author)
        {
            return Ok(await _authorService.Delete(id, author));
        }
    }
}
