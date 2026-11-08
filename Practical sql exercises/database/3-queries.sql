USE TaskManagementDb;
GO

--Exercise — Basic SELECT

--SELECT *
--FROM Users;

--SELECT *
--FROM Tasks;

--SELECT Title, CreatedAt
--FROM Tasks;

--SELECT *
--FROM Tasks WHERE IsCompleted = 0;

--SELECT *
--FROM Tasks WHERE IsCompleted = 1;

--SELECT *
--FROM Tasks WHERE Id = 4;


--Exercise — Filtering

--SELECT Title
--FROM Tasks WHERE UserId = 3;

--SELECT *
--FROM Tasks WHERE Title LIKE '%SQL%';

--SELECT *
--FROM Tasks WHERE CreatedAt > '2026-11-04';

--SELECT*
--FROM Tasks WHERE IsCompleted=0 AND UserId = 2;

--SELECT *
--FROM Users WHERE Name LIKE 'A%';


--Exercise — Sorting

--SELECT *
--FROM Tasks ORDER BY CreatedAt DESC;

--SELECT *
--FROM Tasks ORDER BY CreatedAt ASC;

--SELECT *
--FROM Users ORDER BY Name ASC;

--SELECT *
--FROM Tasks WHERE IsCompleted = 0 ORDER BY CreatedAt ASC;

--Exercise — INSERT

--INSERT INTO Users (Name, Email) VALUES ('Alexey', 'Alexey@outlook.com');

--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn SQL', 'Insert Data ', 1, 4);
--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn IT', 'Technology', 0, 4);
--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn Entity Framework Core', ' ', 0, 4);

--SELECT *
--FROM Users WHERE Email = 'Alexey@outlook.com';

--SELECT *
--FROM Tasks WHERE UserId = 4;



--Exercise — UPDATE

--SELECT *
--FROM Tasks WHERE Title = 'Learn JS';

--UPDATE Tasks SET IsCompleted = 1 WHERE Title =  'Learn JS';

--SELECT *
--FROM Tasks WHERE Title = 'Learn JS';

--SELECT *
--FROM Tasks WHERE Title = 'Learn JS';

--UPDATE Tasks SET Title = 'Deep Learn JS' WHERE Title = 'Learn JS';

--SELECT *
--FROM Tasks WHERE Title = 'Deep Learn JS';

--SELECT *
--FROM Users WHERE Email = 'Michael@gmail.com';

--UPDATE Users SET Email = 'Michael@example.com' WHERE Email = 'Michael@gmail.com';

--SELECT *
--FROM Users WHERE Email = 'Michael@example.com';

--SELECT *
--FROM Tasks WHERE UserId = 4;

--UPDATE Tasks SET IsCompleted = 1 WHERE UserId = 4;

--SELECT *
--FROM Tasks WHERE UserId = 4;


--Exercise — DELETE

--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn Docker', 'Test Task', 0, 4);

--SELECT *
--FROM Tasks WHERE UserId = 4;

--SELECT *
--FROM Tasks
--WHERE Title = 'Learn Docker';

--DELETE
--FROM Tasks WHERE Title = 'Learn Docker';

--SELECT *
--FROM Tasks WHERE Title = 'Learn Docker'


--Exercise — INNER JOIN

--SELECT Tasks.Title, Users.Name, Tasks.IsCompleted FROM Tasks INNER JOIN Users ON Tasks.UserId = Users.Id;

--SELECT *
--FROM Users;


--Exercise — LEFT JOIN

--INSERT INTO Users (Name, Email) VALUES ('Woody', 'Woody@gmail.com');

--SELECT Users.Name, Tasks.Title FROM Users LEFT JOIN Tasks ON Users.Id = Tasks.UserId;

--SELECT *
--FROM Users;

--Exercise — Aggregate Functions

--SELECT COUNT(*) AS TotalUsers
--FROM Users;

--SELECT COUNT(*) AS TotalTasks
--FROM Tasks;

--SELECT COUNT(*) AS CompletedTasks
--FROM Tasks WHERE IsCompleted = 1;

--SELECT COUNT(*) AS IncompletedTasks
--FROM Tasks WHERE IsCompleted = 0;

--SELECT Users.name AS User_Name,
--COUNT(Tasks.id) AS Tasks_Count
--FROM Users LEFT JOIN Tasks ON Users.id = Tasks.UserId
--GROUP BY Users.name;


--Exercise — Users With No Tasks

--SELECT *
--FROM Users LEFT JOIN Tasks ON Tasks.UserId = Users.Id WHERE Tasks.Id IS NULL;


--Exercise — Transactions

--BEGIN TRANSACTION
--SELECT *
--FROM Tasks WHERE Title = 'Build Task Manager';
--UPDATE Tasks SET IsCompleted = 1 WHERE Title =  'Build Task Manager';
--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn IT', '', 0, 2);
--COMMIT;

--SELECT *
--FROM Tasks;

--BEGIN TRANSACTION
--SELECT *
--FROM Tasks WHERE Title = 'Build Task Manager';
--UPDATE Tasks SET IsCompleted = 0 WHERE Title =  'Build Task Manager';
--INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn IT', '', 0, 1234);
--ROLLBACK;

--SELECT *
--FROM Tasks;


--Exercise — Index

--SELECT *
--FROM Tasks WHERE UserId = 1;

--SELECT *
--FROM Tasks WHERE UserId = 3 AND IsCompleted = 0 ORDER BY CreatedAt;


--Challenge — More Realistic Query

--SELECT Name,
--(SELECT COUNT(*) FROM Tasks WHERE Tasks.UserId = Users.Id) AS TotalCount,
--(SELECT COUNT(*) FROM Tasks WHERE Tasks.UserId = Users.Id AND Tasks.IsCompleted = 1) AS Completed,
--(SELECT COUNT(*) FROM Tasks WHERE Tasks.UserId = Users.Id AND Tasks.IsCompleted = 0) AS Incompleted
--FROM Users;


--Challenge — Most Active User

--SELECT TOP 1
--Users.Name, COUNT(Tasks.Id) AS TaskCount
--FROM Users INNER JOIN Tasks ON UserId = Users.Id
--GROUP BY Users.Id, Users.Name
--ORDER BY COUNT(Tasks.Id) DESC;