using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryStore _libraryStore;

        public AuthorsController(LibraryStore libraryStore)
        {
            _libraryStore = libraryStore;
        }

        [HttpGet("api/authors")]
        public IActionResult GetAll()
        {
            var authors = _libraryStore.Authors;
            return Ok(authors);
        }
              

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var author = _libraryStore.Authors.FirstOrDefault(a => a.Id == id);
            if (author is null)            
                return NotFound($"Author with Id {id} not found");
            
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor([FromBody]CreateAuthorRequest request)
        {
            var author = new Author
            {
                Id = _libraryStore.CreateAuthorId(),                
                Name = request.Name,
                DateOfBirth = request.DateOfBirth
            };

            _libraryStore.Authors.Add(author);

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author); 
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorRequest request, int id)
        {
            var author = _libraryStore.Authors.FirstOrDefault(a => a.Id == id);
            if (author is null)
                return NotFound();
            author.Name = request.Name;
            author.DateOfBirth = request.DateOfBirth;
            return Ok(author); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor([FromRoute] int id)
        {
            var author = _libraryStore.Authors.FirstOrDefault(a => a.Id == id);
            if (author is null)
                return NotFound();            

            _libraryStore.Authors.Remove(author);
            return GetAll(); 
        }
    }
}
