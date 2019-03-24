using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public int Add(Attendance o)
        {
            throw new NotImplementedException();
        }

        public bool Close(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Attendance o)
        {
            throw new NotImplementedException();
        }

        public Attendance[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Attendance GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Open(int id, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public bool Open(int id, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Attendance o)
        {
            throw new NotImplementedException();
        }
    }
}
