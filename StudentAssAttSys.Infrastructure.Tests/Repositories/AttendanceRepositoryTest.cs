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
                DateTimeAttendanceStart = DateTime.Parse("01/01/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("02/02/2019")
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
                DateTimeAttendanceStart = DateTime.Parse("03/03/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("03/03/2019")
            };
            int result = Repository.Add(attendance);
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditAttendance()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("03/03/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("04/04/2019")
            });
            Attendance attendance = Repository.GetById(attendanceId);
            DateTime newDateTime = DateTime.Parse("09/09/2019");
            attendance.DateTimeAttendanceEnd = newDateTime;
            bool result = Repository.Edit(attendance);
            attendance = Repository.GetById(attendanceId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(attendance.DateTimeAttendanceEnd, Is.EqualTo(newDateTime).Within(1).Minutes);
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
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = endDateTime
            });
            Attendance attendance = Repository.GetById(attendanceId);
            Assert.That(attendance.DateTimeAttendanceEnd, Is.EqualTo(endDateTime).Within(1).Minutes);
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
        public void IsAttendanceOpenedBetweenDateTimes()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("06/06/2019"));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsAttendanceClosedIfEarlierAndBetween()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("02/02/2019"), DateTime.Parse("06/06/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void IsAttendanceClosedIfBetweenAndLater()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("05/05/2019"), DateTime.Parse("09/09/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void IsAttendanceClosedIfEarlierAndLater()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("02/02/2019"), DateTime.Parse("09/09/2019"));
            Assert.IsFalse(result);
        }

        [Test]
        public void IsAttendanceOpenedGivenEarlierFinish()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("06/06/2019"));
            Assert.IsTrue(result);
        }

        [Test]
        public void IsAttendanceClosedGivenLaterFinish()
        {
            int attendanceId = Repository.Add(new Attendance
            {
                DateTimeAttendanceStart = DateTime.Parse("04/04/2019"),
                DateTimeAttendanceEnd = DateTime.Parse("07/07/2019")
            });
            bool result = Repository.Open(attendanceId, DateTime.Parse("09/09/2019"));
            Assert.IsFalse(result);
        }
    }
}
