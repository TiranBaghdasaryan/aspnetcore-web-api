using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Model;
using my_books.Data.ViewModels;
using my_books.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBookWithAuthors([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Book> books = _booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            BookWithAuthorsVM book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            Book updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(book);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}