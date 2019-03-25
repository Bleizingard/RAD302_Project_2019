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
        }

        [SetUp]
        public void SetUp()
        {
            Repository.Add(new Lecturer
            {
                FirstName = "FirstLecturer"
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
            Lecturer lectuer = new Lecturer
            {
                FirstName = "ShouldAddLecturerTest"
            };
            string result = Repository.Add(lectuer);
            Assert.That(result.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditLecturer()
        {
            string lecturerId = Repository.Add(new Lecturer
            {
                FirstName = "ShouldEditLecturer"
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
        public void ShouldGetAllComments()
        {
            Lecturer[] lecturers = Repository.GetAll();
            Assert.That(lecturers.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByCommentId()
        {
            string lecturerId = Repository.Add(new Lecturer
            {
                FirstName = "GetLecturerByIdTest"
            });
            Lecturer lecturer = Repository.GetById(lecturerId);
            Assert.That(lecturer.FirstName, Is.EqualTo("GetLecturerByIdTest"));
        }

        [Test]
        public void ShouldDeleteComment()
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
