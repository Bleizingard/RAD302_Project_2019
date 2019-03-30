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
    public class CommentRepositoryTest
    {
        private CommentRepository Repository;
        private StudentAssAttSysContext Context;
        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new CommentRepository();
            Context = new StudentAssAttSysContext();
        }

        [SetUp]
        public void SetUp()
        {
            InfrastructureTestsSeed.SeedAll(Context);

            Result result = Context.Results.FirstOrDefault();
            Student student = Context.Students.FirstOrDefault();
            User user = Context.Users.FirstOrDefault();

            Repository.Add(new Comment
            {
                AssessmentId = result.AssessmentId,
                StudentId = result.StudentId,
                UserId = user.Id,
                Message = "FirstComment",
                DateTimeCreation = DateTime.Today
            });
        }

        [TearDown]
        public void CleanUp()
        {
            Comment[] comments = Repository.GetAll();
            foreach (Comment comment in comments)
            {
                Repository.Remove(comment);
            }

            InfrastructureTestsSeed.RemoveAll(Context);
        }

        [Test]
        public void ShouldAddComment()
        {
            Result result = Context.Results.FirstOrDefault();
            Student student = Context.Students.FirstOrDefault();
            User user = Context.Users.FirstOrDefault();

            Comment comment = new Comment
            {
                AssessmentId = result.AssessmentId,
                StudentId = result.StudentId,
                UserId = user.Id,
                Message = "ShouldAddCommentTest",
                DateTimeCreation = DateTime.Today
            };
            int resultB = Repository.Add(comment);
            Assert.That(resultB, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditComment()
        {
            Result result = Context.Results.FirstOrDefault();
            Student student = Context.Students.FirstOrDefault();
            User user = Context.Users.FirstOrDefault();

            int commentId = Repository.Add(new Comment
            {
                AssessmentId = result.AssessmentId,
                StudentId = result.StudentId,
                UserId = user.Id,
                Message = "ShouldEditComment",
                DateTimeCreation = DateTime.Today
            });
            Comment comment = Repository.GetById(commentId);
            comment.Message = "NewMessage";
            bool resultB = Repository.Edit(comment);
            comment = Repository.GetById(commentId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultB);
                Assert.That(comment.Message, Is.EqualTo("NewMessage"));
            });
        }

        [Test]
        public void ShouldGetAllComments()
        {
            Comment[] comments = Repository.GetAll();
            Assert.That(comments.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetByCommentId()
        {
            Result result = Context.Results.FirstOrDefault();
            Student student = Context.Students.FirstOrDefault();
            User user = Context.Users.FirstOrDefault();

            int commentId = Repository.Add(new Comment
            {
                AssessmentId = result.AssessmentId,
                StudentId = result.StudentId,
                UserId = user.Id,
                Message = "GetCommentByIdTest",
                DateTimeCreation = DateTime.Today
            });
            Comment comment = Repository.GetById(commentId);
            Assert.That(comment.Message, Is.EqualTo("GetCommentByIdTest"));
        }

        [Test]
        public void ShouldDeleteComment()
        {
            Comment comment = Repository.GetAll()[0];
            int commentId = comment.Id;
            bool result = Repository.Remove(comment);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.IsNull(Repository.GetById(commentId));
            });
        }
    }
}
