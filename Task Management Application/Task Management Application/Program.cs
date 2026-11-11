using Dapper;
using Microsoft.Data.SqlClient;
using Task_Management_Application.Repositories;

string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Database=TaskManagementDb;" + "Integrated Security=True;"
    + "TrustServerCertificate=True;";
await using var connection = new SqlConnection(connectionString);
Console.WriteLine("Database connection successful.");

string databaseName = await connection.QuerySingleAsync<string>("SELECT DB_NAME()");
Console.WriteLine($"Connected database: {databaseName}");

ITaskRepository repository = new TaskRepository(connectionString);

while (true)
{
    Console.WriteLine("______________________________________________________________________________________________");
    Console.WriteLine("Operations: ");
    Console.WriteLine("1. Press <1> to show all tasks");
    Console.WriteLine("2. Press <2> to show task by ID");
    Console.WriteLine("3. Press <3> to add new task");
    Console.WriteLine("4. Press <4> to update task by ID");
    Console.WriteLine("5. Press <5> to complete task by ID");
    Console.WriteLine("6. Press <6> to delete task by ID");
    Console.Write("Select operation: ");

    string? select = Console.ReadLine();

    switch (select)
    {
        case "1":
            await ShowAllTasksAsync();
            break;
        case "2":
            await GetTasksByIdAsync();
            break;
        case "3":
            await CreateTaskAsync();
            break;
        case "4":
            await UpdateTaskAsync();
            break;
        case "5":
            await CompleteTaskAsync();
            break;
        case "6":
            await DeleteTaskAsync();
            break;
        default:
            Console.WriteLine("Unknown option");
            break;
    }

    async Task ShowAllTasksAsync()
    {
        var tasks = (await repository.GetAllAsync()).ToList();

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks");            
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}: {task.Title} | Description: {task.Description} | Completed: {task.IsCompleted} | Created at: {task.CreatedAt}");
        }            
    }

    async Task GetTasksByIdAsync()
    {
        Console.Write("Enter task id: ");
        int id = SetNumber();
        var task = await repository.GetByIdAsync(id);

        if (task is null)
            Console.WriteLine($"Task with id {id} not found");
        else
            Console.WriteLine($"{task.Id}: {task.Title} | Description: {task.Description} | Completed: {task.IsCompleted} | Created at: {task.CreatedAt}");
    }

    async Task CreateTaskAsync()
    {
        Console.Write("Title: ");
        string? title = Console.ReadLine();

        Console.Write("Description: ");
        string? description = Console.ReadLine();

        int newId = await repository.CreateAsync(title, description);
        Console.WriteLine($"Task created with ID: {newId}");
        var task = await repository.GetByIdAsync(newId);
        Console.WriteLine($"{task.Id}: {task.Title} | Description: {task.Description} | Completed: {task.IsCompleted} | Created at: {task.CreatedAt}");
    }

    async Task UpdateTaskAsync()
    {
        Console.Write("Enter task id: ");
        int id = SetNumber();

        Console.Write("New title: ");
        string? title = Console.ReadLine();

        Console.Write("New description: ");
        string? description = Console.ReadLine();

        bool isUpdated = await repository.UpdateAsync(id, title, description);
        if (isUpdated == false)
        {
            Console.WriteLine($"Task not found with id: {id}");            
        }
        else
        {
            Console.WriteLine($"Task with id {id} was updated");
        }
        var task = await repository.GetByIdAsync(id);
        Console.WriteLine($"{task.Id}: {task.Title} | Description: {task.Description} | Completed: {task.IsCompleted} | Created at: {task.CreatedAt}");
    }

    async Task CompleteTaskAsync()
    {
        Console.WriteLine("Enter task id: ");
        int id = SetNumber();
        bool isCompleted = await repository.CompleteAsync(id);
        if (isCompleted == false)
        {
            Console.WriteLine($"Task not found with id: {id}");            
        }
        else
        {
            Console.WriteLine($"Task with id {id} marked completed");
        }
        var task = await repository.GetByIdAsync(id);
        Console.WriteLine($"{task.Id}: {task.Title} | Description: {task.Description}  | Completed: {task.IsCompleted} | Created at: {task.CreatedAt}");
    }

    async Task DeleteTaskAsync()
    {
        Console.WriteLine("Enter task id: ");
        int id = SetNumber();
        bool isDeleted = await repository.DeleteAsync(id);
        if (isDeleted == false)
        {
            Console.WriteLine($"Task not found with id: {id}");
        }
        else
        {
            Console.WriteLine($"Task with id {id} has been deleted");
        }
    }

    int SetNumber()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            else
            {
                Console.Write("Error! Enter an integer!: ");
            }
        }
    }
}