using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class CommentRepository : IGenericRepository<Comment, int>
    {
        public int Add(Comment o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Comment o)
        {
            throw new NotImplementedException();
        }

        public Comment[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Comment o)
        {
            throw new NotImplementedException();
        }
    }
}
