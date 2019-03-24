CREATE TABLE [dbo].[Comments] (
    [Id]               INT            NOT NULL IDENTITY(1,1),
    [Message]          NVARCHAR (MAX) NULL,
    [DateTimeCreation] DATETIME       NULL,
    [AssessmentId]     INT            NULL,
    [UserId]           INT            NULL,
    [StudentId]        NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comments_ToResults] FOREIGN KEY ([AssessmentId], [StudentId]) REFERENCES [dbo].[Results] ([AssessmentId], [StudentId]) ON DELETE CASCADE
);

