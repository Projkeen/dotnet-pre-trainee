using Dapper;
using Microsoft.Data.SqlClient;
using Task_Management_Application.Models;

namespace Task_Management_Application.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);

            const string GetAllSql = " SELECT Id, Title, Description, IsCompleted, CreatedAt FROM Tasks ORDER BY CreatedAt DESC;";

            var tasks = await connection.QueryAsync<TaskItem>(GetAllSql);
            return tasks;
        }
             
        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            const string GetByIdSql = "SELECT Id, Title, Description, IsCompleted, CreatedAt FROM Tasks WHERE Id = @Id;";

            var task = await connection.QuerySingleOrDefaultAsync<TaskItem>(GetByIdSql, new { Id = id });
            return task;
        }       

        public async Task<int> CreateAsync(string title, string? description)
        {
            await using var connection = new SqlConnection(_connectionString);

            const string CreateSql = """
            INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt)
            OUTPUT INSERTED.Id
            VALUES (@Title, @Description, @IsCompleted, @CreatedAt);
            """;
            TaskItem task = new TaskItem
            {
                Title = title,
                Description = description,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
            };

            var newTask = await connection.QuerySingleAsync<int>(CreateSql,task);
            return newTask;            
        }        

        public async Task<bool> UpdateAsync(int id, string title, string? description)
        {
            await using var connection = new SqlConnection(_connectionString);

            const string sql = "UPDATE Tasks SET Title = @Title, Description = @Description WHERE Id = @Id;";

            int task = await connection.ExecuteAsync(sql, new { Id = id, Title = title, Description = description });
            return task > 0;
        }
            
        public async Task<bool> CompleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            const string sql = "UPDATE Tasks SET IsCompleted = 1 WHERE Id = @Id;";

            int task = await connection.ExecuteAsync(sql, new { Id = id });
            return task > 0;
        }

        public async Task<int?> ReplaceAsync(int oldTaskId, string newTitle, string? newDescription)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string completeSql = "UPDATE Tasks SET IsCompleted = 1 WHERE Id = @Id;";

                int row = await connection.ExecuteAsync(completeSql, new { Id = oldTaskId }, transaction);

                if (row == 0)
                {
                    await transaction.RollbackAsync();
                    return 0;
                }

                const string insertSql = """
                    INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt)
                    OUTPUT INSERTED.Id
                    VALUES (@Title, @Description, @IsCompleted, @CreatedAt);
                    """;
                TaskItem task = new TaskItem
                {
                    Title = newTitle,
                    Description = newDescription,
                    IsCompleted = false,
                    CreatedAt = DateTime.Now,
                };                
                var newTaskId = await connection.QuerySingleAsync<int>(insertSql, task, transaction);     
                await transaction.CommitAsync();
                return newTaskId;
            }
            catch
            {
                await transaction.RollbackAsync();
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            const string sql = "DELETE FROM Tasks WHERE Id = @Id;";

            int task = await connection.ExecuteAsync(sql, new { Id = id });
            return task > 0;
        }
    }
}
