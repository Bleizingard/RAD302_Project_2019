using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class ModuleRepository : IGenericRepository<Module>
    {
        public object Add(Module o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Module o)
        {
            throw new NotImplementedException();
        }

        public List<Module> GetAll()
        {
            throw new NotImplementedException();
        }

        public Module GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Module GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Module o)
        {
            throw new NotImplementedException();
        }
    }
}
