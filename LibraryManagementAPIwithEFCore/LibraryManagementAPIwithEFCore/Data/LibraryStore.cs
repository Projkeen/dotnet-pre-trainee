using LibraryManagementAPIwithEFCore.Models;

namespace LibraryManagementAPIwithEFCore.Data
{
    public class LibraryStore
    {
        public int _nextAuthorId = 1;
        public int _nextBookId = 1;

        public List<Author>? Authors { get; set; } = new();
        public List<Book>? Books { get; set; } = new();

        public LibraryStore()
        {
            var orwell = new Author { Id = CreateAuthorId(), Name = "George Orwell", DateOfBirth = new DateTime(1903, 6, 25) };
            var tolkien = new Author { Id = CreateAuthorId(), Name = "J.R.R. Tolkien", DateOfBirth = new DateTime(1892, 1, 3) };
            var martin = new Author { Id = CreateAuthorId(), Name = "Robert C. Martin", DateOfBirth = new DateTime(1952, 12, 5) };
            Authors.AddRange([orwell, tolkien, martin]);

            Books.Add(new Book { Id = CreateBookId(), Title = "1984", PublishedYear = 1949, AuthorId = orwell.Id });
            Books.Add(new Book { Id = CreateBookId(), Title = "The Hobbit", PublishedYear = 1937, AuthorId = tolkien.Id });
            Books.Add(new Book { Id = CreateBookId(), Title = "Clean Code", PublishedYear = 2008, AuthorId = martin.Id });
        }

        public int CreateAuthorId()
        {
            return _nextAuthorId++;
        }

        public int CreateBookId()
        {
            return _nextBookId++;
        }
    }
}
