CREATE TABLE [dbo].[Attendances] (
    [Id]                      INT           NOT NULL,
    [DateTimeLectureStart]    DATETIME      NULL,
    [DateTimeLectureEnd]      DATETIME      NULL,
    [DateTimeAttendanceStart] DATETIME      NULL,
    [DateTimeAttendanceEnd]   DATETIME      NULL,
    [LecturerId]              NVARCHAR (20) NULL,
    [ModuleId]                INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Attendances_ToLecturers] FOREIGN KEY (LecturerId) REFERENCES Lecturers(Id), 
    CONSTRAINT [FK_Attendances_ToModules] FOREIGN KEY (ModuleId) REFERENCES Modules(Id)
);

