using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;
using System;

namespace LibraryManagementApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryStore _libraryStore;

        public AuthorService(LibraryStore libraryStore)
        {
            _libraryStore = libraryStore;
        }

        public bool CheckAuthorExisting(int id)
        {
            var check = _libraryStore.Authors.Where(a => a.Id == id).FirstOrDefault();
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

        public Author CreateAuthor(CreateAuthorRequest createAuthorRequest)
        {
            var author = new Author
            {
                Id = _libraryStore.CreateAuthorId(),
                Name = createAuthorRequest.Name,
                DateOfBirth = createAuthorRequest.DateOfBirth
            };

            _libraryStore.Authors?.Add(author);
            return author;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _libraryStore.Authors.FirstOrDefault(a => a.Id == id);
            if (author is null)
                return false;
            _libraryStore.Authors.Remove(author);
            return true;
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _libraryStore.Authors;
            return authors;
        }

        public Author GetAuthorById(int id)
        {
            var author = _libraryStore.Authors?.FirstOrDefault(a => a.Id == id);
            return author;
        }

        public bool UpdateAuthor(UpdateAuthorRequest updateAuthorRequest, int id)
        {
            var author = _libraryStore.Authors?.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return false;
            author.Name = updateAuthorRequest.Name;
            author.DateOfBirth = updateAuthorRequest.DateOfBirth;
            return true;
        }
    }
}
