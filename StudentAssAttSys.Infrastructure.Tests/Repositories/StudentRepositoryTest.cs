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
    public class StudentRepositoryTest
    {
        private StudentRepository Repository;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new StudentRepository();

            CleanUp();

        }

        [SetUp]
        public void SetUp()
        {
            Student student = new Student
            {
                Id = "heuiheufh",
                User = new User
                {
                    FirstName = "FirstStudent",
                    LastName = "Test",
                    Email = "SXXXXXX0@mail.itsligo.ie"
                },
                StudentNumber = "SXXXXXX0"
            };

            Repository.Add(student);
        }

        [TearDown]
        public void CleanUp()
        {
            Student[] students = Repository.GetAll();
            foreach (Student student in students)
            {
                Repository.Remove(student);
            }
        }

        [Test]
        public void ShouldAddStudent()
        {
            Student student = new Student
            {
                Id = "euiheufh",
                User = new User
                {
                    FirstName = "ShouldAddStudentTest",
                    LastName = "Test",
                    Email = "SXXXXXXX@mail.itsligo.ie"
                },
                StudentNumber = "SXXXXXXX"                
            };
            string result = Repository.Add(student);
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(result);
                Assert.That(result, Is.Not.EqualTo("-1"));
            });
        }

        [Test]
        public void ShouldEditStudent()
        {
            string studentId = Repository.Add(new Student
            {
                Id = "euiheufh",
                User = new User
                {
                    FirstName = "ShouldAddStudentTest",
                    LastName = "Test",
                    Email = "SXXXXXXX@mail.itsligo.ie"
                },
                StudentNumber = "SXXXXXXX"
            });
            Student student = Repository.GetById(studentId);
            student.User.FirstName = "NewFirstname";
            bool result = Repository.Edit(student);
            student = Repository.GetById(studentId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(student.User.FirstName, Is.EqualTo("NewFirstname"));
            });
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            Student[] students = Repository.GetAll();
            Assert.That(students.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByStudentId()
        {
            string studentId = Repository.Add(new Student
            {
                Id = "euiheufh",
                User = new User
                {
                    FirstName = "ShouldGetByStudentIdTest",
                    LastName = "Test",
                    Email = "SXXXXXXX@mail.itsligo.ie"
                },
                StudentNumber = "SXXXXXXX"
            });
            Student student = Repository.GetById(studentId);
            Assert.That(student.User.FirstName, Is.EqualTo("ShouldGetByStudentIdTest"));
        }

        [Test]
        public void ShouldDeleteStudent()
        {
            Student student = Repository.GetAll()[0];
            string studentId = student.Id;
            bool result = Repository.Remove(student);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.IsNull(Repository.GetById(studentId));
            });
        }
    }
}
