using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class LecturerRepository : IGenericRepository<Lecturer, string>
    {
        public string Add(Lecturer o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Lecturer o)
        {
            throw new NotImplementedException();
        }

        public Lecturer[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Lecturer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Lecturer o)
        {
            throw new NotImplementedException();
        }
    }
}
