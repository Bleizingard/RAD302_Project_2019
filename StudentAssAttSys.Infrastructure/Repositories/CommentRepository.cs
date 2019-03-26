using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class CommentRepository : IGenericRepository<Comment, int>
    {
        private StudentAssAttSysContext context { get; set; }

        public CommentRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Comment</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new Comment or <c>-1</c> if it fails</returns>
         */
        public int Add(Comment o)
        {
            try
            {

                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch
            {
                return -1;
            }
        }

        /**
         * <summary>Edit <c>Comment</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Comment o)
        {
            Comment comment = GetById(o.Id);
            if (comment == null)
            {
                return false;
            }

            try
            {
                comment.Id = o.Id;
                comment.AssessmentId = o.AssessmentId;
                comment.DateTimeCreation = o.DateTimeCreation;
                comment.Message = o.Message;
                comment.Result = o.Result;
                comment.StudentId = o.StudentId;
                comment.User = o.User;
                comment.UserId = o.UserId;

                context.Entry(comment).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Comment</c> from the database</summary>
         * <returns>Returns an array of all comments</returns>
         */
        public Comment[] GetAll()
        {
            return context.Comments.ToArray();
        }

        /**
         * <summary>Get <c>Comment</c> from the database</summary>
         * <returns>Returns a <c>Comment</c> or <c>null</c> if nothing found</returns>
         */
        public Comment GetById(int id)
        {
            return context.Comments.FirstOrDefault(c => c.Id == id);
        }

        /**
         * <summary>Remove <c>Comment</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Comment o)
        {
            try
            {
                context.Entry(o).State = EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
