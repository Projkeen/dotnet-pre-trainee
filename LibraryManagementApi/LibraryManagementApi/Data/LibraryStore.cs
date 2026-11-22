using LibraryManagementApi.Models;

namespace LibraryManagementApi.Data
{
    public class LibraryStore
    {
        public int _nextAuthorId = 1;
        public int _nextBookId = 1;

        public List<Author>? Authors { get; set; } = new();
        public List<Book>? Books { get; set; } = new();

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
