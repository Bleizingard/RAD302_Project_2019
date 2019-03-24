using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class ResultRepository : IGenericRepository<Result, KeyValuePair<int, string>>
    {
        public KeyValuePair<int, string> Add(Result o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Result o)
        {
            throw new NotImplementedException();
        }

        public Result[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Result GetById(KeyValuePair<int, string> id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Result o)
        {
            throw new NotImplementedException();
        }
    }
}
