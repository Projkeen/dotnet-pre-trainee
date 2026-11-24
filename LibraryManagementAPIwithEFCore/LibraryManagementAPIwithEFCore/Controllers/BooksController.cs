using LibraryManagementAPIwithEFCore.Data;
using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
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
        public IActionResult GetAll([FromQuery] string? searchByTitle, [FromQuery] int? authorId)
        {
            var books = _books.GetAll(searchByTitle, authorId);
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

        [HttpPost]
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
