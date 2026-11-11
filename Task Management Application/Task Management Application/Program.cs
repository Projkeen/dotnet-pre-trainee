using Dapper;
using Microsoft.Data.SqlClient;

string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Database=TaskManagementDb;" + "Integrated Security=True;"
    + "TrustServerCertificate=True;";
await using var connection = new SqlConnection(connectionString);
Console.WriteLine("Database connection successful.");

string databaseName = await connection.QuerySingleAsync<string>("SELECT DB_NAME()");
Console.WriteLine($"Connected database: {databaseName}");