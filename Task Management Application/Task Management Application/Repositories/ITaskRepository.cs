using Task_Management_Application.Models;

namespace Task_Management_Application.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();        
        Task<TaskItem?> GetByIdAsync(int id);        
        Task<int> CreateAsync(string title, string? description);       
        Task<bool> UpdateAsync(int id, string title, string? description);
        Task<bool> CompleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<int?> ReplaceAsync(int oldTaskId, string newTitle, string? newDescription);
    }
}
