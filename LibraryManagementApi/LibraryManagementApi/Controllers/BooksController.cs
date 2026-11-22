using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryStore _libraryStore;

        public BooksController(LibraryStore libraryStore)
        {
            _libraryStore = libraryStore;
        }

        [HttpGet("api/books")]
        public IActionResult GetAll()
        {
            var books = _libraryStore.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _libraryStore.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)            
                return NotFound($"Book with Id {id} not found");
            
            return Ok(book);
        }

        [HttpPost("api/books-create")]
        public IActionResult CreateBook([FromBody] CreateBookRequest request)
        {
            var book = new Book
            {
                Id = _libraryStore.CreateBookId(),
                Title = request.Title,
                PublishedYear = request.PublishedYear,
                AuthorId = request.AuthorId
            };

            _libraryStore.Books.Add(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromBody] UpdateBookRequest request, int id)
        {
            var book = _libraryStore.Books.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return NotFound();
            book.Title = request.Title;
            book.PublishedYear = request.PublishedYear;  
            book.AuthorId = request.AuthorId;
            return Ok(book);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = _libraryStore.Books.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return NotFound();

            _libraryStore.Books.Remove(book);
            return GetAll();
        }
    }
}
