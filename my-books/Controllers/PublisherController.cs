using Microsoft.AspNetCore.Mvc;
using my_books.Data.ViewModels;
using my_books.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublisherController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-with-books/{id}")]
        public IActionResult AddPublisher(int id)
        {
            var result = _publishersService.GetPublisherWithBooksById(id);
            return Ok(result);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}