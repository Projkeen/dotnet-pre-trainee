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

        public AuthorsController(IAuthorService authors)
        {
            _authors = authors;
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
        public ActionResult<Author> CreateAuthor([FromBody]CreateAuthorRequest request)
        {
            var author = _authors.CreateAuthor(request);

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author); 
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorRequest request, int id)
        {
            var checkAuthor = _authors.UpdateAuthor(request, id);
            if (checkAuthor is false)
                return NotFound($"Author with Id {id} not found");            
            return Ok(checkAuthor); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor([FromRoute] int id)
        {
            var checkAuthor = _authors.DeleteAuthor(id);
            if (checkAuthor is false)
                return NotFound($"Author with Id {id} not found");   
            
            return GetAll(); 
        }
    }
}
