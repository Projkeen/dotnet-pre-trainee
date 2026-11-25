using LibraryManagementAPIwithEFCore.Data;
using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
using LibraryManagementAPIwithEFCore.Responses;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagementAPIwithEFCore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _libraryContext;

        public AuthorService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<bool> CheckAuthorExistingAsync(int id)
        {
            var check = await _libraryContext.Authors.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (check is null)
                return false;
            return true;
        }

        public bool CheckNotInFuture(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
                return true;
            return false;
        }

        public async Task<AuthorResponse> CreateAuthorAsync(CreateAuthorRequest createAuthorRequest)
        {
            var author = new Author
            {
                //Id = _libraryContext.CreateAuthorId(),
                Name = createAuthorRequest.Name,
                DateOfBirth = createAuthorRequest.DateOfBirth
            };
            _libraryContext.Authors?.Add(author);
            await _libraryContext.SaveChangesAsync();
            var response = new AuthorResponse
            {
                Id = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Books = author.Books
            };
            return response;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _libraryContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
                return false;
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAsync()
        {
            IQueryable<Author> authors = _libraryContext.Authors.AsNoTracking();
            var response = authors.Select(a => new AuthorResponse
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Books = a.Books
            });
            return await response.ToListAsync();
        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(int id)
        {
            IQueryable<Author> authors = _libraryContext.Authors.AsNoTracking().Where(a => a.Id == id);
            var response = authors.Select(a => new AuthorResponse
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Books = a.Books
            });            
            return await response.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAuthorAsync(UpdateAuthorRequest updateAuthorRequest, int id)
        {
            var author = await _libraryContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
                return false;
            author.Name = updateAuthorRequest.Name;
            author.DateOfBirth = updateAuthorRequest.DateOfBirth;
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckBookByAuthorAsync(int id)
        {
            var checkBook = await _libraryContext.Books.AnyAsync(b => b.AuthorId == id);
            if (checkBook is false) return true;
            return false;
        }
    }
}
