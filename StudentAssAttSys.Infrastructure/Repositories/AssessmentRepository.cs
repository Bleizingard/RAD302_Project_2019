using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class AssessmentRepository : IGenericRepository<Assessment, int>
    {
        public int Add(Assessment o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Assessment o)
        {
            throw new NotImplementedException();
        }

        public Assessment[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Assessment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Assessment o)
        {
            throw new NotImplementedException();
        }
    }
}
