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
                User = new User
                {
                    Id = "euiheufh",
                    FirstName = "FirstLecturer",
                    LastName = "Test",
                    Email = "FirstLecturerTest@mail.itsligo.ie"
                }
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
                User = new User
                {
                    Id = "heuiheufh",
                    FirstName = "ShouldAddLecturer",
                    LastName = "Test",
                    Email = "FirstLecturerTest@mail.itsligo.ie"
                }
            };
            string result = Repository.Add(lecturer);

            lecturer = Repository.GetById(result);

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(result);
                Assert.That(result, Is.Not.EqualTo("-1"));
                Assert.IsNotNull(lecturer);
            });
        }

        [Test]
        public void ShouldEditLecturer()
        {
            string lecturerId = Repository.Add(new Lecturer
            {
                Id = "heuiheufh",
                User = new User
                {
                    Id = "heuiheufh2",
                    FirstName = "ShouldEditLecturer",
                    LastName = "Test",
                    Email = "FirstLecturerTest@mail.itsligo.ie"
                }
            });
            Lecturer lecturer = Repository.GetById(lecturerId);
            lecturer.User.FirstName = "NewFirstname";
            bool result = Repository.Edit(lecturer);
            lecturer = Repository.GetById(lecturerId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(lecturer.User.FirstName, Is.EqualTo("NewFirstname"));
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
                Id = "heuiheufh2",
                User = new User
                {
                    Id = "heuiheufh2",
                    FirstName = "ShouldGetByLecturerId",
                    LastName = "Test",
                    Email = "FirstLecturerTest@mail.itsligo.ie"
                }
            });
            Lecturer lecturer = Repository.GetById(lecturerId);
            Assert.That(lecturer.User.FirstName, Is.EqualTo("ShouldGetByLecturerId"));
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
