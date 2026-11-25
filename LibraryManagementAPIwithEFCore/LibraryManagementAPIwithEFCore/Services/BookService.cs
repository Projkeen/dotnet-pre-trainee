using LibraryManagementAPIwithEFCore.Data;
using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
using LibraryManagementAPIwithEFCore.Responses;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPIwithEFCore.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;
        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest)
        {
            var book = new Book
            {                
                Title = createBookRequest.Title,
                PublishedYear = createBookRequest.PublishedYear,
                AuthorId = createBookRequest.AuthorId,
            };
            _libraryContext.Books?.Add(book);
            await _libraryContext.SaveChangesAsync();
            
            return await GetBookByIdAsync(book.Id);            
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (book is null)
                return false;
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookResponse>> GetAllAsync(string? searchByTitle = null, int? authorId = null, int? publishedYear = null)
        {
            IQueryable<Book> books = _libraryContext.Books.AsNoTracking();
            if (!string.IsNullOrEmpty(searchByTitle))
                books = books.Where(b => b.Title.Contains(searchByTitle));
            if (authorId.HasValue)
                books = books.Where(b => b.AuthorId == authorId.Value);
            if (publishedYear.HasValue)
                books = books.Where(b => b.PublishedYear == publishedYear.Value);
            var response = books.Select(a => new BookResponse
            {
                Id = a.Id,
                Title = a.Title,
                PublishedYear = a.PublishedYear,
                AuthorId = a.AuthorId,
                AuthorName = a.Author.Name,
            });          
            return await response.ToListAsync(); 
        }

        public async Task<BookResponse> GetBookByIdAsync(int id)
        {
            IQueryable<Book> books = _libraryContext.Books.AsNoTracking().Where(a => a.Id == id);
            var response = books.Select(a => new BookResponse
            {
                Id = a.Id,
                Title = a.Title,
                PublishedYear = a.PublishedYear,
                AuthorId = a.AuthorId,
                AuthorName = a.Author.Name,
            });
            return await response.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBookAsync(UpdateBookRequest updateBookRequest, int id)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (book is null)
                return false;
            book.Title = updateBookRequest.Title;
            book.PublishedYear = updateBookRequest.PublishedYear;
            book.AuthorId = updateBookRequest.AuthorId;
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckBookByAuthorAsync(int authorId)
        {
            var checkBook = await _libraryContext.Books.Where(b => b.AuthorId == authorId).FirstOrDefaultAsync();
            if (checkBook is null) return true;
            return false;
        }

        public async Task<IEnumerable<BookResponse>> GetPublishedAfter2015Async()
        {
            var books = _libraryContext.Books.AsNoTracking().Where(b => b.PublishedYear > 2015).OrderByDescending(b => b.PublishedYear).ThenBy(b => b.Title);
            var response = books.Select(a => new BookResponse
            {
                Id = a.Id,
                Title = a.Title,
                PublishedYear = a.PublishedYear,
                AuthorId = a.AuthorId,
                AuthorName = a.Author.Name,
            });
            return await response.ToListAsync();
        }
    }
}
