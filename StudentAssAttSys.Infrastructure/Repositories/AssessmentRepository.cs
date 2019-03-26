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
    public class AssessmentRepository : IGenericRepository<Assessment, int>
    {
        private StudentAssAttSysContext context { get; set; }
        public AssessmentRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Assessment</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new <c>Assessment</c> or <c>-1</c> if it fails</returns>
         */
        public int Add(Assessment o)
        {
            try
            {
                o.Id = 0;
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /**
         * <summary>Edit <c>Assessment</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Assessment o)
        {
            Assessment assessment = GetById(o.Id);
            if (assessment == null)
            {
                return false;
            }

            try
            {
                assessment.Id = o.Id;
                assessment.DateTimeEnd = o.DateTimeEnd;
                assessment.DateTimeStart = o.DateTimeStart;
                assessment.Lecturer = o.Lecturer;
                assessment.LecturerId = o.LecturerId;
                assessment.Module = o.Module;
                assessment.ModuleId = o.ModuleId;
                assessment.Results = o.Results;

                context.Entry(assessment).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /**
         * <summary>Get all <c>Assessments</c> from the database</summary>
         * <returns>Returns an array of all arrays</returns>
         */
        public Assessment[] GetAll()
        {
            return context.Assessments.ToArray();
        }

        /**
         * <summary>Get <c>Assessment</c> from the database</summary>
         * <returns>Returns an <c>Assessment</c> or <c>null</c> if nothing found</returns>
         */
        public Assessment GetById(int id)
        {
            return context.Assessments.FirstOrDefault(m => m.Id == id);
        }

        /**
         * <summary>Remove <c>Assessment</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Remove(Assessment o)
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
