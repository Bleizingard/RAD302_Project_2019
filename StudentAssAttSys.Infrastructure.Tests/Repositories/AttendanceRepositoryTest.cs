using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Infrastructure.Repositories;

namespace StudentAssAttSys.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class AttendanceRepositoryTest
    {
        private AttendanceRepository Repository;
        private StudentAssAttSysContext dbContext = new StudentAssAttSysContext();

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new AttendanceRepository();

            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            InfrastructureTestsSeed.SeedModules(dbContext);
            InfrastructureTestsSeed.SeedLecturers(dbContext);
            Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("06/06/2019"),
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("05/05/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
        }

        [TearDown]
        public void CleanUp()
        {
            Attendance[] attendances = Repository.GetAll();
            foreach (Attendance attendance in attendances)
            {
                Repository.Remove(attendance);
            }
            InfrastructureTestsSeed.RemoveLecturers(dbContext);
            InfrastructureTestsSeed.RemoveModules(dbContext);
        }

        [Test]
        public void ShouldAddAttendance()
        {
            Attendance attendance = new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("06/06/2019"),
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("05/05/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            };
            int result = Repository.Add(attendance);
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditAttendance()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("04/04/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            Attendance attendance = Repository.GetById(attendanceId);
            DateTime newDateTime = DateTime.Parse("09/09/2019");
            attendance.DateTimeLectureEnd = newDateTime;
            bool result = Repository.Edit(attendance);
            attendance = Repository.GetById(attendanceId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(attendance.DateTimeLectureEnd, Is.EqualTo(newDateTime).Within(1).Minutes);
            });
        }

        [Test]
        public void ShouldGetAllAttendances()
        {
            Attendance[] attendances = Repository.GetAll();
            Assert.That(attendances.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByAttendanceId()
        {
            DateTime endDateTime = DateTime.Parse("05/05/2019");
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("04/04/2019"),
                DateTimeLectureEnd = endDateTime,
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            Attendance attendance = Repository.GetById(attendanceId);
            Assert.That(attendance.DateTimeLectureEnd, Is.EqualTo(endDateTime).Within(1).Minutes);
        }

        [Test]
        public void ShouldDeleteAttendance()
        {
            Attendance attendance = Repository.GetAll()[0];
            int attendanceId = attendance.Id;
            bool result = Repository.Remove(attendance);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.IsNull(Repository.GetById(attendanceId));
            });
        }

        [Test]
        public void OpenAttendance()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("04/04/2019"),
                DateTimeLectureEnd = DateTime.Parse("07/07/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("06/06/2019"));
            Assert.IsTrue(result);
        }

        [Test]
        public void NotOpenAttendanceBecauseIsAlreadyStarted()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("08/08/2019"),
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("06/06/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void NotOpenBecauseStartIsLaterThanFinish()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("04/04/2019"),
                DateTimeLectureEnd = DateTime.Parse("07/07/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("06/06/2019"), DateTime.Parse("05/05/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void NotOpenBecauseAttendanceEarlierThanLecture()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("04/04/2019"),
                DateTimeLectureEnd = DateTime.Parse("07/07/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("02/02/2019"), DateTime.Parse("06/06/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void NotOpenBecauseAttendanceLaterThanLecture()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("04/04/2019"),
                DateTimeLectureEnd = DateTime.Parse("07/07/2019"),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("08/08/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void CloseAttendance()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Now.AddHours(-1),
                DateTimeLectureEnd = DateTime.Now.AddHours(1),
                DateTimeAttendanceStart = DateTime.Now.AddHours(-1),
                DateTimeAttendanceEnd = DateTime.Now.AddHours(1),
                LecturerId = dbContext.Lecturers.FirstOrDefault().Id,
                ModuleId = dbContext.Modules.FirstOrDefault().Id
            });

            bool result = Repository.Close(attendanceId);
            Assert.IsTrue(result);
        }
    }
}
