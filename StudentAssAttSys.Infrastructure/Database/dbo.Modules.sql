CREATE TABLE [dbo].[Modules] (
    [Id]            INT          NOT NULL IDENTITY(1,1),
    [Name]          NVARCHAR(50)   NULL UNIQUE,
    [GPAPercentage] DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

