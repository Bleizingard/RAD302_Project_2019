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
    public class ModuleRepository : IGenericRepository<Module, int>
    {
        private StudentAssAttSysContext context { get; set; }

        public ModuleRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Module</c> in the database</summary>
         * <returns>Returns the ID of the new Module</returns>
         */

        public int Add(Module o)
        {
            try
            {

                o.Id = 0;
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
         * <summary>Edit <c>Module</c> in the database</summary>
         * <returns>Returns true if succeed else false</returns>
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
            return context.Modules.ToArray();
        }
        /**
         * <summary>Get <c>Module</c> from the database</summary>
         * <returns>Returns a <c>Module</c> or <c>null</c> if nothing found</returns>
         */
        public Module GetById(int id)
        {
            return context.Modules.FirstOrDefault(m => m.Id == id);
        }
        /**
         * <summary>Remove <c>Module</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Module o)
        {
            try
            {
                context.Entry(o).State = EntityState.Added;
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
