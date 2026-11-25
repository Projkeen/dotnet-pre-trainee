using LibraryManagementAPIwithEFCore.Data;
using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
using LibraryManagementAPIwithEFCore.Responses;
using LibraryManagementAPIwithEFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPIwithEFCore.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchByName)
        {
            return Ok(await _authors.GetAllAsync(searchByName));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var author = await _authors.GetAuthorByIdAsync(id);
            if (author is null)
                return NotFound($"Author with Id {id} not found");
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            if (!_authors.CheckNotInFuture(request.DateOfBirth))
                return BadRequest(new { error = "Invalid dateOfBirth", message = "dateOfBirth must be not in future" });
            var author = await _authors.CreateAuthorAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request, int id)
        {
            if (!_authors.CheckNotInFuture(request.DateOfBirth))
                return BadRequest(new { error = "Invalid dateOfBirth", message = "dateOfBirth must be not in future" });
            var checkAuthor = await _authors.UpdateAuthorAsync(request, id);
            if (checkAuthor is false)
                return NotFound($"Author with Id {id} not found");
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            if (!await _authors.CheckAuthorExistingAsync(id))
                return NotFound($"Author with Id {id} not found");
            if (!await _authors.CheckBookByAuthorAsync(id))
                return Conflict(new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = $"Author with id {id} has books. Delete his books"
                });
            var checkAuthor = await _authors.DeleteAuthorAsync(id);
            return NoContent();
        }

        [HttpGet("get-book-counts")]
        public async Task<IActionResult> GetBookCounts()
        {
            var countBooks = await _authors.GetBookCountByAuthorAsync();
            return Ok(countBooks);
        }
      
    }
}
