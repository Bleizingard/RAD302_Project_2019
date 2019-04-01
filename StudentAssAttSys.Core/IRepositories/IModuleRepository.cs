using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAssAttSys.Core.Core;

namespace StudentAssAttSys.Core.IRepositories
{
    public interface IModuleRepository : IGenericRepository<Module, int>
    {
        int AddLecturer(int moduleId, string lecturerId);
    }
}
