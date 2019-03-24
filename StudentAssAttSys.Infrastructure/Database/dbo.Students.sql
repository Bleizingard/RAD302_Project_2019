CREATE TABLE [dbo].[Students] (
    [Id]            NVARCHAR (100) NOT NULL,
    [FirstName]     NVARCHAR (50)  NULL,
    [LastName]      NVARCHAR (50)  NULL,
    [Email]         NVARCHAR (50)  NULL UNIQUE,
    [StudentNumber] NVARCHAR (20)  NULL UNIQUE,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

