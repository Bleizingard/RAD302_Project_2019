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

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Repository = new CommentRepository();
        }

        [SetUp]
        public void SetUp()
        {
            Repository.Add(new Comment
            {
                Message = "FirstComment"
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
        }

        [Test]
        public void ShouldAddComment()
        {
            Comment comment = new Comment
            {
                Message = "ShouldAddCommentTest"
            };
            int result = Repository.Add(comment);
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldEditComment()
        {
            int commentId = Repository.Add(new Comment
            {
                Message = "ShouldEditComment"
            });
            Comment comment = Repository.GetById(commentId);
            comment.Message = "NewMessage";
            bool result = Repository.Edit(comment);
            comment = Repository.GetById(commentId);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
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
            int commentId = Repository.Add(new Comment
            {
                Message = "GetCommentByIdTest"
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
