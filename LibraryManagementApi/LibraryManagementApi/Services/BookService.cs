using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryStore _libraryStore;
        public BookService(LibraryStore libraryStore)
        {
            _libraryStore = libraryStore;
        }

        public Book CreateBook(CreateBookRequest createBookRequest)
        {
            var book = new Book
            {
                Id = _libraryStore.CreateBookId(),
                Title = createBookRequest.Title,
                PublishedYear = createBookRequest.PublishedYear,
                AuthorId = createBookRequest.AuthorId
            };
            _libraryStore.Books?.Add(book);
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = _libraryStore.Books?.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return false;
            _libraryStore.Books?.Remove(book);
            return true;
        }

        public IEnumerable<Book> GetAll(string? searchByTitle = null, int? authorId = null)
        {
            var books = _libraryStore.Books;
            if (!string.IsNullOrEmpty(searchByTitle))
                books = (books?.Where(b => b.Title?.ToLower() == searchByTitle.ToLower()).ToList());
            if (authorId.HasValue)
                books = (books?.Where(b => b.AuthorId == authorId.Value).ToList());
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _libraryStore.Books?.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public bool UpdateBook(UpdateBookRequest updateBookRequest, int id)
        {
            var book = _libraryStore.Books?.FirstOrDefault(a => a.Id == id);
            if (book is null)
                return false;
            book.Title = updateBookRequest.Title;
            book.PublishedYear = updateBookRequest.PublishedYear;
            book.AuthorId = updateBookRequest.AuthorId;
            return true;
        }

        public bool CheckBookByAuthor(int authorId)
        {
            var checkBook = _libraryStore.Books?.Where(b => b.AuthorId == authorId).FirstOrDefault();
            if (checkBook is null) return true;
            return false;
        }        
    }
}
