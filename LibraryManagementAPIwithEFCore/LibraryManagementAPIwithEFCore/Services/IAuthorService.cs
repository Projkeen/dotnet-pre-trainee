using LibraryManagementAPIwithEFCore.Models;
using LibraryManagementAPIwithEFCore.Requests;
using LibraryManagementAPIwithEFCore.Responses;

namespace LibraryManagementAPIwithEFCore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponse>> GetAllAsync();
        Task<AuthorResponse> GetAuthorByIdAsync(int id);
        Task<AuthorResponse> CreateAuthorAsync(CreateAuthorRequest createAuthorRequest);
        Task<bool> UpdateAuthorAsync(UpdateAuthorRequest updateAuthorRequest, int id);
        Task<bool> DeleteAuthorAsync(int id);
        Task<bool> CheckAuthorExistingAsync(int id);
        Task<bool> CheckBookByAuthorAsync(int id);
        bool CheckNotInFuture(DateTime dateTime);
    }
}
