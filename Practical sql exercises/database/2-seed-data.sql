USE TaskManagementDb;
GO
INSERT INTO Users (Name, Email) VALUES ('Anna', 'Anna@gmail.com');
INSERT INTO Users (Name, Email) VALUES ('John', 'John@outlook.com');
INSERT INTO Users (Name, Email) VALUES ('Michael', 'Michael@gmail.com');

INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn SQL', 'Transactions', 0, 1);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn SQL', 'Practice JOINs', 1, 2);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn SQL', 'Read about indexes', 0, 3);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Build Task Manager', 'C# Console App', 0, 1);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn Dapper', 'Something new', 1, 3);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn .NET', 'Api', 0, 2);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn JS', 'Frontend', 0, 2);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn git', '& Github', 1, 3);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn C#', 'Basic coding', 0, 2);
INSERT INTO Tasks (Title, Description, IsCompleted, UserId) VALUES ('Learn Design patterns', '', 0, 1);