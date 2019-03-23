CREATE TABLE [dbo].[Assessments] (
    [Id]            INT           NOT NULL,
    [DateTimeStart] DATETIME      NULL,
    [DateTimeEnd]   DATETIME      NULL,
    [LecturerId]    NVARCHAR (20) NULL,
    [ModuleId]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Assessments_ToLecturers] FOREIGN KEY (LecturerId) REFERENCES Lecturers(Id), 
    CONSTRAINT [FK_Assessments_ToModule] FOREIGN KEY (ModuleId) REFERENCES Modules(Id)
);

