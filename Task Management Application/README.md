# \# Task Management Application





## \## About



Console application for managing tasks. You can create task, view task(s), update data in task, mark a task as completed, delete task. All data stored in a SQL Server database. Every sql-queries is written using SQL and Dapper.





## \## Technologies



* C#
* .NET
* SQL Server
* Dapper
* Microsoft.Data.SqlClient





## \## Features



* Show all tasks: display all tasks from the database;
* Show task by ID: show one task;
* Add new task: create a task with a title and a description. New task is not completed (default db table settings) and get the current creation date;
* Update task by ID: changes the title and the description of a task;
* Complete task by ID: marks a task as completed;
* Delete task by ID: remove a task from the database;
* Mark task as complete and create new task: transaction has two db operations treated as one logical unit using sql;
* Input validation, exception handling, the application continues to run until the user selects the <exit> function.





## \## Database Setup



Console application uses local database (server name = localdb)\\\\MSSQLLocalDB). Use queries in SQL Server Management Studio.

1. Create database by executing sql-query in file "database/create-database.sql". Database name is "TaskManagementDb";
2. Create table by executing sql-query in file "database/create-table.sql". Table name is "Tasks";
3. Add starting data to the table by executing sql-query in file "database/seed-data.sql".





## \## Project Structure



* Model: Class TaskItem has 5 fields (Id, Title, Description, IsCompleted, CreatedAt);
* Repository: "ITaskRepository" is interface which defines the available operations, "TaskRepository" class implements them, contains the connection creation to database, sql queries;
* Console layer: "Program" class where program starts and has user input and work with Repository.





## \## Concepts Practiced



* CRUD: create, read, update and delete operations with tasks;
* Asynchronous database access: keyword "async" and "await", Dapper methods "QueryAsync", "QuerySingleOrDefaultAsync", "ExecuteAsync";
* Repository Pattern: database access code in other layer with  UI (console menu);
* Parameterized queries: all data are entered through SQL parameters ("@Id", "@Title" and other) to protect against SQL injection from users input;
* SQL Server persistence: all data is stored in the database, and after restarting the application you can access it.





## \## How to Run



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2\. Use Database Setup above;



3\. Go to the project folder, where exist file .csproj:



cd "dotnet-pre-trainee/Task Management Application/Task Management Application"



4\. Run the application:



dotnet run











### 

