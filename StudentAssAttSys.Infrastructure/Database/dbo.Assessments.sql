CREATE TABLE [dbo].[Assessments] (
    [Id]            INT            NOT NULL IDENTITY(1,1),
    [DateTimeStart] DATETIME       NULL,
    [DateTimeEnd]   DATETIME       NULL,
    [LecturerId]    NVARCHAR (100) NULL,
    [ModuleId]      INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Assessments_ToModule] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Assessments_ToLecturers] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturers] ([Id]) ON DELETE CASCADE
);

