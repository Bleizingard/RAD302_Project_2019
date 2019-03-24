using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class StudentRepository : IGenericRepository<Student, string>
    {
        public string Add(Student o)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Student o)
        {
            throw new NotImplementedException();
        }

        public Student[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Student o)
        {
            throw new NotImplementedException();
        }
    }
}
