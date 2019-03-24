using StudentAssAttSys.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.IRepositories
{
    public interface IAttendanceRepository : IGenericRepository<Attendance, int>
    {
        bool Open(int id, DateTime startDateTime, DateTime endDateTime);
        bool Open(int id, DateTime endDateTime);
        bool Close(int id);

    }
}
