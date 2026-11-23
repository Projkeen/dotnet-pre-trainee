using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll(string searchByTitle, int? authorId = null);
        Book GetBookById(int id);
        Book CreateBook(CreateBookRequest createBookRequest);
        bool UpdateBook(UpdateBookRequest updateBookRequest, int id);
        bool DeleteBook(int id);
        bool CheckBookByAuthor(int authorId);
    }
}
