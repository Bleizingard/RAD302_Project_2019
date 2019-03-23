CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Message] NVARCHAR(MAX) NULL, 
    [DateTimeCreation] DATETIME NULL, 
    [ResultId] INT NULL, 
    [UserId] INT NULL
)
