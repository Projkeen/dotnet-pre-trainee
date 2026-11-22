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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _books;
        private readonly IAuthorService _authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            _books = books;
            _authors = authors;
        }

        [HttpGet("api/books")]
        public IActionResult GetAll([FromQuery] string? searchByTitle)
        {
            var books = _books.GetAll(searchByTitle);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _books.GetBookById(id);
            if (book is null)
                return NotFound($"Book with Id {id} not found");
            return Ok(book);
        }

        [HttpPost("api/books-create")]
        public IActionResult CreateBook([FromBody] CreateBookRequest request)
        {
            if (!_authors.CheckAuthorExisting(request.AuthorId))
                return BadRequest();
            var book = _books.CreateBook(request);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromBody] UpdateBookRequest request, int id)
        {
            if (!_authors.CheckAuthorExisting(request.AuthorId))
                return BadRequest();
            var checkBook = _books.UpdateBook(request, id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var checkBook = _books.DeleteBook(id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");
            return NoContent();
        }
    }
}
