using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetBookById(int id);
        Book CreateBook(CreateBookRequest createBookRequest);
        bool UpdateBook(UpdateBookRequest updateBookRequest, int id);
        bool DeleteBook(int id);
    }
}
