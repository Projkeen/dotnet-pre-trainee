using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
using LibraryManagementAPIwithEFCore.Responses;

namespace LibraryManagementAPIwithEFCore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllAsync(string searchByTitle, int? authorId = null, int? publishedYear = null);
        Task<BookResponse> GetBookByIdAsync(int id);
        Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest);
        Task<bool> UpdateBookAsync(UpdateBookRequest updateBookRequest, int id);
        Task<bool> DeleteBookAsync(int id);
        Task<bool> CheckBookByAuthorAsync(int authorId);
        Task<IEnumerable<BookResponse>> GetPublishedAfter2015Async();
    }
}
