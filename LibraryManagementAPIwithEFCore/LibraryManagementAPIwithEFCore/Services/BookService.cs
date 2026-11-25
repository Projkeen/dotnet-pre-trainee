using LibraryManagementAPIwithEFCore.Data;
using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;

namespace LibraryManagementAPIwithEFCore.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;
        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Book CreateBook(CreateBookRequest createBookRequest)
        {
            var book = new Book
            {
                //Id = _libraryContext.CreateBookId(),
                Title = createBookRequest.Title,
                PublishedYear = createBookRequest.PublishedYear,
                AuthorId = createBookRequest.AuthorId
            };
            _libraryContext.Books?.Add(book);
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = _libraryContext.Books?.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return false;
            _libraryContext.Books?.Remove(book);
            return true;
        }

        public IEnumerable<Book> GetAll(string? searchByTitle = null, int? authorId = null)
        {
            var books = _libraryContext.Books;
            //if (!string.IsNullOrEmpty(searchByTitle))
            //    books = (books?.Where(b => b.Title?.ToLower() == searchByTitle.ToLower()).ToList());
            //if (authorId.HasValue)
            //    books = (books?.Where(b => b.AuthorId == authorId.Value).ToList());
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _libraryContext.Books?.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public bool UpdateBook(UpdateBookRequest updateBookRequest, int id)
        {
            var book = _libraryContext.Books?.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return false;
            book.Title = updateBookRequest.Title;
            book.PublishedYear = updateBookRequest.PublishedYear;
            book.AuthorId = updateBookRequest.AuthorId;
            return true;
        }

        public bool CheckBookByAuthor(int authorId)
        {
            var checkBook = _libraryContext.Books?.Where(b => b.AuthorId == authorId).FirstOrDefault();
            if (checkBook is null) return true;
            return false;
        }        
    }
}
