CREATE TABLE [dbo].[Users] (
    [Id]        NVARCHAR (20) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

