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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _books;
        private readonly IAuthorService _authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            _books = books;
            _authors = authors;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchByTitle, [FromQuery] int? authorId, [FromQuery] int? publishedYear)
        {
            var books = await _books.GetAllAsync(searchByTitle, authorId, publishedYear);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _books.GetBookByIdAsync(id);
            if (book is null)
                return NotFound($"Book with Id {id} not found");
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            if (!await _authors.CheckAuthorExistingAsync(request.AuthorId))
                return BadRequest();
            var book = await _books.CreateBookAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request, int id)
        {
            if (!await _authors.CheckAuthorExistingAsync(request.AuthorId))
                return BadRequest($"Author with id {request.AuthorId} not found");
            var checkBook = await _books.UpdateBookAsync(request, id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");                     
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var checkBook = await _books.DeleteBookAsync(id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");
            return NoContent();
        }

        [HttpGet("get-published-after-2015")]
        public async Task<ActionResult<List<BookResponse>>> GetPublishedAfter2015()
        {
            var filteredBook = await _books.GetPublishedAfter2015Async();
            return Ok(filteredBook);
        }
        
    }
}
