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
            throw new NotImplementedException();
        }
        /**
         * <summary>Get all <c>Module</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public Module[] GetAll()
        {
            throw new NotImplementedException();
        }
        /**
         * <summary>Get <c>Module</c> from the database</summary>
         * <returns>Returns a <c>List</c> of <c>Module</c></returns>
         */
        public Module GetById(int id)
        {
            throw new NotImplementedException();
        }
        /**
         * <summary>Remove <c>Module</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Module o)
        {
            throw new NotImplementedException();
        }
    }
}
