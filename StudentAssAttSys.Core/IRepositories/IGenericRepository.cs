using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.IRepositories
{
    /**
     * <typeparam name="T">Object</typeparam>
     * <typeparam name="Y">Type of the PrimaryKey of T</typeparam>
     */
    public interface IGenericRepository<T, Y>
    {
        T GetById(Y id);
        Y Add(T o);
        bool Edit(T o);
        bool Remove(T o);
        List<T> GetAll();
    }
}
