CREATE TABLE [dbo].Students_Attendances
(
    [StudentId] NVARCHAR(100) NOT NULL, 
    [AttendanceId] INT NOT NULL, 
    CONSTRAINT [PK_Students_Attendances] PRIMARY KEY (StudentId, AttendanceId), 
    CONSTRAINT [FK_Students_Attendances_ToStudents] FOREIGN KEY (StudentId) REFERENCES Students(Id), 
    CONSTRAINT [FK_Students_Attendances_ToAttendaces] FOREIGN KEY (AttendanceId) REFERENCES Attendances(ID)
)
