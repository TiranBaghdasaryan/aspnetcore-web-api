using Microsoft.AspNetCore.Mvc;
using my_books.Data.ViewModels;
using my_books.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            AuthorWithBooksVM result = _authorsService.GetAuthorWithBooks(id);
            return Ok(result);
        }

        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsService.DeleteAuthorById(id);
            return Ok();
        }
    }
}