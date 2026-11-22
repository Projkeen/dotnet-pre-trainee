using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;
using LibraryManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authors;
        private readonly IBookService _books;
        public AuthorsController(IAuthorService authors, IBookService books)
        {
            _authors = authors;
            _books = books;
        }

        [HttpGet("api/authors")]
        public IActionResult GetAll()
        {
            return Ok(_authors.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var author = _authors.GetAuthorById(id);
            if (author is null)
                return NotFound($"Author with Id {id} not found");
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            if (!_authors.CheckNotInFuture(request.DateOfBirth))
                return BadRequest();
            var author = _authors.CreateAuthor(request);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorRequest request, int id)
        {
            if (!_authors.CheckNotInFuture(request.DateOfBirth))
                return BadRequest();
            var checkAuthor = _authors.UpdateAuthor(request, id);
            if (checkAuthor is false)
                return NotFound($"Author with Id {id} not found");
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor([FromRoute] int id)
        {
            if (!_authors.CheckAuthorExisting(id))
                return NotFound($"Author with Id {id} not found");
            if (!_books.CheckBookByAuthor(id))
                return Conflict(new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = $"Author with id {id} has books. Delete his books"
                });
            var checkAuthor = _authors.DeleteAuthor(id);
            return NoContent();
        }
    }
}
