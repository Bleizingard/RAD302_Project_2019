using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class ResultRepository : IGenericRepository<Result, KeyValuePair<int, string>>
    {
        private StudentAssAttSysContext context { get; set; }

        public ResultRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Result</c> in the database</summary>
         * <returns>Returns the <c>KeyValuePair<AssessmentId, StudentId></c> of the new Result or <c>KeyValuePair<-1,"-1"></c> if it fails</returns>
         */
        public KeyValuePair<int, string> Add(Result o)
        {
            try
            {

                o.AssessmentId = 0;
                o.StudentId = "";
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return new KeyValuePair<int, string>(o.AssessmentId,o.StudentId);
            }
            catch
            {
                return new KeyValuePair<int, string>(-1,"-1");
            }
        }

        /**
         * <summary>Edit <c>Result</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Result o)
        {
            Result result = GetById(new KeyValuePair<int, string>(o.AssessmentId, o.StudentId));

            if (result == null)
            {
                return false;
            }

            try
            {
                result.Assessment = o.Assessment;
                result.AssessmentId = o.AssessmentId;
                result.StudentId = o.StudentId;
                result.Comments = o.Comments;
                result.Grade = o.Grade;
                result.Student = o.Student;

                context.Entry(result).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Results</c> from the database</summary>
         * <returns>Returns an array of all results</returns>
         */
        public Result[] GetAll()
        {
            return context.Results.ToArray();
        }

        /**
         * <summary>Get <c>Result</c> from the database</summary>
         * <returns>Returns a <c>Result</c> or <c>null</c> if nothing found</returns>
         */
        public Result GetById(KeyValuePair<int, string> id)
        {
            return context.Results.FirstOrDefault(r => r.AssessmentId == id.Key && r.StudentId == id.Value);
        }

        /**
         * <summary>Remove <c>Result</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Result o)
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
