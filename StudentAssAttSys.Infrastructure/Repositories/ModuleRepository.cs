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
    public class ModuleRepository : IModuleRepository
    {
        private StudentAssAttSysContext context { get; set; }

        public ModuleRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Module</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new Module or <c>-1</c> if it fails</returns>
         */

        public int Add(Module o)
        {
            try
            {
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        /**
         * <summary>Edit <c>Module</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Module o)
        {
            Module module = GetById(o.Id);
            if (module == null)
            {
                return false;
            }

            try
            {
                module.Id = o.Id;
                module.Assessments = o.Assessments;
                module.Attendances = o.Attendances;
                module.GPAPercentage = o.GPAPercentage;
                module.Lecturers = o.Lecturers;
                module.Name = o.Name;
                module.Students = o.Students;

                context.Entry(module).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Module</c> from the database</summary>
         * <returns>Returns an array of all modules</returns>
         */
        public Module[] GetAll()
        {
            return context.Modules.Include(m => m.Students).Include(m => m.Lecturers)
                .Include("Students.User").Include("Lecturers.User")
                .Include(m => m.Assessments).Include(m => m.Attendances).ToArray();
        }

        /**
         * <summary>Get <c>Module</c> from the database</summary>
         * <returns>Returns a <c>Module</c> or <c>null</c> if nothing found</returns>
         */
        public Module GetById(int id)
        {
            return context.Modules.Include(m => m.Students).Include(m => m.Lecturers)
                .Include("Students.User").Include("Lecturers.User")
                .Include(m => m.Assessments).Include(m => m.Attendances)
                .FirstOrDefault(m => m.Id == id);
        }

        /**
         * <summary>Remove <c>Module</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Module o)
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

        /**
         * <summary>Add <c>Lecturer</c> to the <c>Module</c></summary>
         * <returns>Returns <c>moduleId</c> if succeed or <c>-1</c>if not</returns>
         */
        public int AddLecturer(int moduleId, string lecturerId)
        {
            Module module = GetById(moduleId);
            Lecturer lecturer = context.Lecturers.FirstOrDefault(l => l.Id.Equals(lecturerId));

            if (module == null || lecturer == null)
            {
                return -1;
            }

            try
            {
                module.Lecturers.Add(lecturer);
                context.Entry(module).State = EntityState.Modified;
                context.SaveChanges();

                lecturer.Modules.Add(module);
                context.Entry(lecturer).State = EntityState.Modified;
                context.SaveChanges();
                return moduleId;
            }
            catch (Exception e)
            {
                return -1;
            }
            
        }
    }
}
