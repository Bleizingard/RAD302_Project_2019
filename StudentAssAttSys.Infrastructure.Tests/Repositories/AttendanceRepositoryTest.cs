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

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new AttendanceRepository();
        }

        [SetUp]
        public void SetUp()
        {
            Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("01/01/2019"),
                DateTimeLectureEnd = DateTime.Parse("02/02/2019"),
                LecturerId = 1,
                ModuleId = 1
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
        }

        [Test]
        public void ShouldAddAttendance()
        {
            Attendance attendance = new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("03/03/2019"),
                LecturerId = 2,
                ModuleId = 2
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
                DateTimeLectureEnd = DateTime.Parse("04/04/2019")
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
                LecturerId = 4,
                ModuleId = 4
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
                LecturerId = 1,
                ModuleId = 1
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
                LecturerId = 1,
                ModuleId = 1
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
                LecturerId = 1,
                ModuleId = 1
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
                LecturerId = 1,
                ModuleId = 1,
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
                LecturerId = 1,
                ModuleId = 1,
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("08/08/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void CloseAttendance()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeLectureStart = DateTime.Parse("03/03/2019"),
                DateTimeLectureEnd = DateTime.Parse("08/08/2019"),
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019"),
                LecturerId = 1,
                ModuleId = 1
            });

            bool result = Repository.Close(attendanceId);
            Assert.IsTrue(result);
        }
    }
}
