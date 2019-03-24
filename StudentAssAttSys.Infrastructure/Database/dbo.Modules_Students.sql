CREATE TABLE [dbo].Modules_Students
(
    [ModuleId] INT NOT NULL, 
    [StudentId] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_Modules_Students] PRIMARY KEY (ModuleId,StudentId), 
    CONSTRAINT [FK_Modules_Students_ToModules] FOREIGN KEY (ModuleId) REFERENCES Modules(Id), 
    CONSTRAINT [FK_Modules_Students_ToStudents] FOREIGN KEY (StudentId) REFERENCES Students(Id)
)
