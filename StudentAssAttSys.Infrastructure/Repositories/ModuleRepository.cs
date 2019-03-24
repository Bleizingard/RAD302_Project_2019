using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class ModuleRepository : IGenericRepository<Module, int>
    {
        private StudentAssAttSysContext context;
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
            return context.Modules.Add(o).Id;
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

            module.Id = o.Id;
            module.Assessments = o.Assessments;
            module.Attendances = o.Attendances;
            module.GPAPercentage = o.GPAPercentage;
            module.Lecturers = o.Lecturers;
            module.Name = o.Name;
            module.Students = o.Students;
            context.SaveChanges();
            return true;
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
            Module deletedModule = context.Modules.Remove(o);
            if (deletedModule == null)
            {
                return false;
            }

            return true;
        }
    }
}
