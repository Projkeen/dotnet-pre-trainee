## \# Practical sql exercises





## \## About



Small database for a Task Management System. The project stores 2 tables: "Users" and "Tasks". The project demonstrates the core SQL concepts such as:

* creating tables, inserting data;
* filtering and sorting, updating and deleting records;
* primary and foreign keys, relationships;
* JOINs;
* aggregate functions;
* transactions;
* basic index design.





## \## Database structure



Database has 2 tables:

* Users

Table has 4 columns: Id (Primary key), Name (NOT NULL), EMAIL (NOT NULL, UNIQUE), CreatedAt (NOT NULL, DateTime of creation via function GETDATE()).

* Tasks

Table has 6 columns: Id (Primary key), Title (NOT NULL), Description (Can be NULL), IsCompleted (Boolean, NOT NULL, DEFAULT 0), CreatedAt (NOT NULL, DateTime of creation via function GETDATE()), UserId (NOT NULL, Foreign key for Users.Id).





## \## Relationship between Users and Tasks



The relationship is one-to-many:

* One user can have many tasks;
* Each task belongs to special one user, by using Foreign key (UserId).





## \## Instructions for creating the database



Use a client such as SQL Server Management Studio (SSMS) or another client. Open files and execute queries.

1. 0-create-and-select-database.sql (create "TaskManagementDb" database);
2. 1-create-tables.sql (creates tables "Users" and "Tasks").





## \## Instructions for adding test data



Open file 2-seed-data.sql and execute it to insert data (3 users and 10 tasks).





## \## Short explanation of the queries practiced



Open file 4-indexes.sql and execute it. Open file 3-queries.sql. Uncomment part what you need and execute queries.

* SELECT (Show all users, all tasks, selected columns, completed and incompleted tasks, task by Id using keyword WHERE);
* Filtering (keywords WHERE, AND, LIKE needs for search rows with specific words or symbols);
* Sorting (keyword ORDER BY needs for sorting tasks ascending (ASC) or descending (DECS) by date and users in alphabetical order;
* INSERT (Using for adding a new user and several tasks);
* UPDATE (Using for changing data in rows, before executing an UPDATE, need run a SELECT with the same WHERE condition);
* DELETE (Query delete only one specific row, before running the DELETE, the target row is checked using the SELECT keyword with WHERE condition);
* INNER JOIN (Show tasks (first table) with names of their users (second table) in one table);
* LEFT JOIN (Show all users including users without tasks);
* Aggregate functions (Calculate tasks per user using COUNT() function);
* Users without a tasks (Find users without a tasks using LEFT JOIN and IS NULL condition);
* Transactions (Two operations in one query. Changing fields in different rows or creating a new record at the same transaction (together). If everything is correct using keyword COMMIT, if one operation is failed data will roll back using keyword ROLLBACK);
* Indexes (Index is a database structure that helps SQL Server find data more efficiently. Created index Tasks\_UserId\_Index for Tasks(UserId) and Tasks\_UserId\_IsCompleted\_CreatedAt\_Index for Tasks(UserId, IsCompleted, CreatedAt));
* Challenge (Query displays table with fields Name, TotalCount, Completed, Incompleted and show count of tasks for each user respectively. Find most active user and show his count of tasks);





## \## Database Concepts Practiced



* CRUD (Create == INSERT, Read == SELECT, Update == UPDATE, Delete == DELETE);
* Primary Keys ("Id" in both tables uniquely identifies a row (record), it's generated automatically with "IDENTITY(1,1)";
* Foreign Keys ("Tasks.UserId" references "Users.Id", connects each task with user);
* One-to-Many Relationships (One user can have many tasks, one task belongs to one user);
* JOINs ("INNER JOIN" shows only matching rows with data in both tables; "LEFT JOIN" shows users with tasks and without tasks, matching from the left table (Users) to right table (Tasks);
* Transactions (Several operations are executed as one as one logical unit: either all succeed ("COMMIT") or none are applied ("ROLLBACK"));
* Indexes (Is a database structure that helps SQL Server find data more efficiently).

