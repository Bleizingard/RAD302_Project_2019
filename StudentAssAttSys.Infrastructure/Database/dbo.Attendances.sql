CREATE TABLE [dbo].[Attendances] (
    [Id]                      INT            NOT NULL IDENTITY(1,1),
    [DateTimeLectureStart]    DATETIME       NULL,
    [DateTimeLectureEnd]      DATETIME       NULL,
    [DateTimeAttendanceStart] DATETIME       NULL,
    [DateTimeAttendanceEnd]   DATETIME       NULL,
    [LecturerId]              NVARCHAR (100) NULL,
    [ModuleId]                INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attendances_ToModules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Attendances_ToLecturers] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturers] ([Id]) ON DELETE CASCADE
);

