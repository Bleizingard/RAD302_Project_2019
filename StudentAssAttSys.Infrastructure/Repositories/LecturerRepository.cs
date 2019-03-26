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
    public class LecturerRepository : IGenericRepository<Lecturer, string>
    {
        private StudentAssAttSysContext context { get; set; }

        public LecturerRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Lecturer</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new Lecturer or <c>"-1"</c> if it fails</returns>
         */
        public string Add(Lecturer o)
        {
            try
            {
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch
            {
                return "-1";
            }
        }

        public bool Edit(Lecturer o)
        {
            Lecturer lecturer = GetById(o.Id);
            if (lecturer == null)
            {
                return false;
            }

            try
            {
                lecturer.Id = o.Id;
                lecturer.Assessments = o.Assessments;
                lecturer.Attendances = o.Attendances;
                lecturer.Comments = o.Comments;
                lecturer.Email = o.Email;
                lecturer.FirstName = o.FirstName;
                lecturer.LastName = o.LastName;
                lecturer.Modules = o.Modules;

                context.Entry(lecturer).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Lecturers</c> from the database</summary>
         * <returns>Returns an array of all lecturers</returns>
         */
        public Lecturer[] GetAll()
        {
            return context.Lecturers.ToArray();
        }

        /**
         * <summary>Get <c>Lecturer</c> from the database</summary>
         * <returns>Returns a <c>Lecturer</c> or <c>null</c> if nothing found</returns>
         */
        public Lecturer GetById(string id)
        {
            return context.Lecturers.FirstOrDefault(l => l.Id.Equals(id));
        }

        /**
         * <summary>Remove <c>Lecturer</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Lecturer o)
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
