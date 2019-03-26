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
    public class AssessmentRepositoryTest
    {
        private AssessmentRepository Repository;
        private StudentAssAttSysContext Context;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new AssessmentRepository();
            Context = new StudentAssAttSysContext();

            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            InfrastructureTestsSeed.SeedStudents(Context);
            InfrastructureTestsSeed.SeedLecturers(Context);
            InfrastructureTestsSeed.SeedModules(Context);
            InfrastructureTestsSeed.SeedModuleLinks(Context);

            Repository.Add(new Assessment
            {
                LecturerId = Context.Lecturers.First().Id,
                ModuleId = Context.Modules.First().Id,
                DateTimeStart = DateTime.Parse("01/01/2019"),
                DateTimeEnd = DateTime.Parse("02/02/2019")
            });
        }

        [TearDown]
        public void CleanUp()
        {
            Assessment[] assessments = Repository.GetAll();
            foreach (Assessment assessment in assessments)
            {
                Repository.Remove(assessment);
            }

            InfrastructureTestsSeed.RemoveModules(Context);
            InfrastructureTestsSeed.RemoveLecturers(Context);
            InfrastructureTestsSeed.RemoveStudents(Context);
        }

        [Test]
        public void ShouldAddAssessment()
        {
            Assessment assessment = new Assessment
            {
                LecturerId = Context.Lecturers.First().Id,
                ModuleId = Context.Modules.First().Id,
                DateTimeStart = DateTime.Parse("03/03/2019"),
                DateTimeEnd = DateTime.Parse("03/03/2019")

            };
            int result = Repository.Add(assessment);
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditAssessment()
        {
            int assessmentId = Repository.Add(new Assessment
            {
                LecturerId = Context.Lecturers.First().Id,
                ModuleId = Context.Modules.First().Id,
                DateTimeStart = DateTime.Parse("03/03/2019"),
                DateTimeEnd = DateTime.Parse("04/04/2019")
            });
            Assessment assessment = Repository.GetById(assessmentId);
            DateTime newDateTime = DateTime.Parse("09/09/2019");
            assessment.DateTimeEnd = newDateTime;
            bool result = Repository.Edit(assessment);
            assessment = Repository.GetById(assessmentId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(assessment.DateTimeEnd,Is.EqualTo(newDateTime).Within(1).Minutes);
            });
        }

        [Test]
        public void ShouldGetAllAssessments()
        {
            Assessment[] assessments = Repository.GetAll();
            Assert.That(assessments.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByAssessmentId()
        {
            DateTime endDateTime = DateTime.Parse("05/05/2019");
            int assessmentId = Repository.Add(new Assessment
            {
                LecturerId = Context.Lecturers.First().Id,
                ModuleId = Context.Modules.First().Id,
                DateTimeStart = DateTime.Parse("04/04/2019"),
                DateTimeEnd = endDateTime
            });
            Assessment assessment = Repository.GetById(assessmentId);
            Assert.That(assessment.DateTimeEnd, Is.EqualTo(endDateTime).Within(1).Minutes);
        }

        [Test]
        public void ShouldDeleteAssessment()
        {
            Assessment assessment = Repository.GetAll()[0];
            int assessmentId = assessment.Id;
            bool result = Repository.Remove(assessment);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.IsNull(Repository.GetById(assessmentId));
            });
        }
    }
}
