using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Infrastructure.Repositories;

namespace StudentAssAttSys.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class LecturerRepositoryTest
    {
        private LecturerRepository Repository;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new LecturerRepository();

            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            Repository.Add(new Lecturer
            {
                Id = "euiheufh",
                FirstName = "FirstLecturer",
                LastName = "Test",
                Email = "FirstLecturerTest@mail.itsligo.ie"
            });
        }

        [TearDown]
        public void CleanUp()
        {
            Lecturer[] lecturers = Repository.GetAll();
            foreach (Lecturer lecturer in lecturers)
            {
                Repository.Remove(lecturer);
            }
        }

        [Test]
        public void ShouldAddLecturer()
        {
            Lecturer lecturer = new Lecturer
            {
                Id = "heuiheufh",
                FirstName = "ShouldAddLecturer",
                LastName = "Test",
                Email = "FirstLecturerTest@mail.itsligo.ie"
            };
            string result = Repository.Add(lecturer);
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(result);
                Assert.That(result, Is.Not.EqualTo("-1"));
            });
        }

        [Test]
        public void ShouldEditLecturer()
        {
            string lecturerId = Repository.Add(new Lecturer
            {
                Id = "heuiheufh",
                FirstName = "ShouldEditLecturer",
                LastName = "Test",
                Email = "FirstLecturerTest@mail.itsligo.ie"
            });
            Lecturer lecturer = Repository.GetById(lecturerId);
            lecturer.FirstName = "NewFirstname";
            bool result = Repository.Edit(lecturer);
            lecturer = Repository.GetById(lecturerId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(lecturer.FirstName, Is.EqualTo("NewFirstname"));
            });
        }

        [Test]
        public void ShouldGetAllLecturers()
        {
            Lecturer[] lecturers = Repository.GetAll();
            Assert.That(lecturers.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByLecturerId()
        {
            string lecturerId = Repository.Add(new Lecturer
            {
                Id = "heuiheufh",
                FirstName = "ShouldGetByLecturerId",
                LastName = "Test",
                Email = "FirstLecturerTest@mail.itsligo.ie"
            });
            Lecturer lecturer = Repository.GetById(lecturerId);
            Assert.That(lecturer.FirstName, Is.EqualTo("ShouldGetByLecturerId"));
        }

        [Test]
        public void ShouldDeleteLecturer()
        {
            Lecturer lecturer = Repository.GetAll()[0];
            string lecturerId = lecturer.Id;
            bool result = Repository.Remove(lecturer);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.IsNull(Repository.GetById(lecturerId));
            });
        }
    }
}
