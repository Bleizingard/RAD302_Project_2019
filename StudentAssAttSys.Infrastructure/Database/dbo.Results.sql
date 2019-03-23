CREATE TABLE [dbo].[Results] (
    [AssessmentId] INT           NOT NULL,
    [StudentId]    NVARCHAR (20) NULL,
    [Grade]        INT           NULL, 
    CONSTRAINT [FK_Results_ToAssessments] FOREIGN KEY (AssessmentId) REFERENCES Assessments(Id), 
    CONSTRAINT [FK_Results_ToStudents] FOREIGN KEY (StudentId) REFERENCES Students(Id)
);

