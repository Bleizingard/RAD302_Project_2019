using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.IRepositories
{
    public interface IGenericRepository<T, Y>
    {
        T GetById(Y id);
        Y Add(T o);
        bool Edit(T o);
        bool Remove(T o);
        List<T> GetAll();
    }
}
