CREATE TABLE [dbo].Modules_Lecturers
(
    [ModuleId] INT NOT NULL, 
    [LecturerId] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_Modules_Lecturers] PRIMARY KEY (ModuleId, LecturerId), 
    CONSTRAINT [FK_Modules_Lecturers_Modules] FOREIGN KEY (ModuleId) REFERENCES Modules(Id), 
    CONSTRAINT [FK_Modules_Lecturers_ToLecturers] FOREIGN KEY (LecturerId) REFERENCES Lecturers(Id)
)
