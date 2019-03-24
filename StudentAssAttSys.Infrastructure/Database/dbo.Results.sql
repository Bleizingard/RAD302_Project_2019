CREATE TABLE [dbo].[Results] (
    [AssessmentId] INT            NOT NULL,
    [StudentId]    NVARCHAR (100) NOT NULL,
    [Grade]        INT            NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [StudentId] ASC),
    CONSTRAINT [FK_Results_ToAssessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Results_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);

