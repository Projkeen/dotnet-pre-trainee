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

        public BooksController(IBookService books)
        {
            _books = books;
        }

        [HttpGet("api/books")]
        public IActionResult GetAll()
        {
            var books = _books.GetAll();
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
            var book = _books.CreateBook(request);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromBody] UpdateBookRequest request, int id)
        {
            var checkBook = _books.UpdateBook(request, id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");           
            return Ok(checkBook);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var checkBook = _books.DeleteBook(id);
            if (checkBook is false)
                return NotFound($"Book with Id {id} not found");                     
            return GetAll();
        }
    }
}
