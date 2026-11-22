using LibraryManagementApi.Models;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();
        Author GetAuthorById(int id);
        Author CreateAuthor(CreateAuthorRequest createAuthorRequest);
        bool UpdateAuthor(UpdateAuthorRequest updateAuthorRequest, int id);
        bool DeleteAuthor(int id);
        bool CheckAuthorExisting(int id);
        bool CheckNotInFuture(DateTime dateTime);
    }
}
