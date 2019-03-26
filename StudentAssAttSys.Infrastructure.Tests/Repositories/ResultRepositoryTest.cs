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
    public class ResultRepositoryTest
    {
        private ResultRepository Repository;
        private StudentAssAttSysContext dbContext = new StudentAssAttSysContext();

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new ResultRepository();
            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            InfrastructureTestsSeed.SeedAll(dbContext);

            Repository.Add(new Result
            {
                AssessmentId = dbContext.Assessments.FirstOrDefault().Id,
                StudentId = dbContext.Students.FirstOrDefault().Id,
                Grade = 55
            });
        }

        [TearDown]
        public void CleanUp()
        {
            Result[] results = Repository.GetAll();
            foreach (Result result in results)
            {
                Repository.Remove(result);
            }
            InfrastructureTestsSeed.RemoveAll(dbContext);
        }

        [Test]
        public void ShouldAddResult()
        {
            Result result = new Result
            {
                Grade = 79
            };
            KeyValuePair<int, string> added = Repository.Add(result);
            Assert.Multiple(() =>
            {
                Assert.That(added.Key,Is.GreaterThan(0));
                Assert.That(added.Value.Length,Is.GreaterThan(0));
            });
        }

        [Test]
        public void ShouldEditResult()
        {
            KeyValuePair<int, string> resultId = Repository.Add(new Result
            {
                Grade = 44
            });
            Result result = Repository.GetById(resultId);
            result.Grade = 99;
            bool edited = Repository.Edit(result);
            result = Repository.GetById(resultId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(edited);
                Assert.That(result.Grade, Is.EqualTo(99));
            });
        }

        [Test]
        public void ShouldGetAllResults()
        {
            Result[] results = Repository.GetAll();
            Assert.That(results.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByResultId()
        {
            KeyValuePair<int,string> resultId = Repository.Add(new Result
            {
                Grade = 65
            });
            Result result = Repository.GetById(resultId);
            Assert.That(result.Grade, Is.EqualTo(65));
        }

        [Test]
        public void ShouldDeleteResult()
        {
            Result result = Repository.GetAll()[0];
            KeyValuePair<int,string> resultId = new KeyValuePair<int, string>(result.AssessmentId,result.StudentId);
            bool deleted = Repository.Remove(result);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(deleted);
                Assert.IsNull(Repository.GetById(resultId));
            });
        }
    }
}
