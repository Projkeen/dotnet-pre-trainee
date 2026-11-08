USE TaskManagementDb;
GO

CREATE INDEX Tasks_UserId_Index
ON Tasks(UserId);
GO

CREATE INDEX Tasks_UserId_IsCompleted_CreatedAt_Index
ON Tasks (UserId, IsCompleted, CreatedAt);
GO