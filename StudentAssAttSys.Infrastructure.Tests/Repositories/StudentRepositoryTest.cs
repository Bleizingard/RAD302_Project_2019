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
        }

        [SetUp]
        public void SetUp()
        {
            Repository.Add(new Student
            {
                FirstName = "FirstStudent"
            });
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
                FirstName = "ShouldAddStudentTest"
            };
            string result = Repository.Add(student);
            Assert.That(result.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditStudent()
        {
            string studentId = Repository.Add(new Student
            {
                FirstName = "ShouldEditStudent"
            });
            Student student = Repository.GetById(studentId);
            student.FirstName = "NewFirstname";
            bool result = Repository.Edit(student);
            student = Repository.GetById(studentId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(student.FirstName, Is.EqualTo("NewFirstname"));
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
                FirstName = "GetStudentByIdTest"
            });
            Student student = Repository.GetById(studentId);
            Assert.That(student.FirstName, Is.EqualTo("GetStudentByIdTest"));
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
