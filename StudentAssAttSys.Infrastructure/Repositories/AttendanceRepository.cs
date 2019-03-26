using StudentAssAttSys.Core.Core;
using StudentAssAttSys.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private StudentAssAttSysContext context { get; set; }

        public AttendanceRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Attendance</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new Attendance or <c>-1</c> if it fails</returns>
         */
        public int Add(Attendance o)
        {
            try
            {

                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        /**
         * <summary>Edit <c>Attendance</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Attendance o)
        {
            Attendance attendance = GetById(o.Id);
            if (attendance == null)
            {
                return false;
            }

            try
            {
                attendance.Id = o.Id;
                attendance.DateTimeAttendanceEnd = o.DateTimeAttendanceEnd;
                attendance.DateTimeAttendanceStart = o.DateTimeAttendanceStart;
                attendance.DateTimeLectureEnd = o.DateTimeLectureEnd;
                attendance.DateTimeLectureStart = o.DateTimeLectureStart;
                attendance.Lecturer = o.Lecturer;
                attendance.LecturerId = o.LecturerId;
                attendance.Module = o.Module;
                attendance.ModuleId = o.ModuleId;
                attendance.PresentStudents = o.PresentStudents;

                context.Entry(attendance).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Attendances</c> from the database</summary>
         * <returns>Returns an array of all attendances</returns>
         */
        public Attendance[] GetAll()
        {
            return context.Attendances.ToArray();
        }

        /**
         * <summary>Get <c>Attendance</c> from the database</summary>
         * <returns>Returns a <c>Attendance</c> or <c>null</c> if nothing found</returns>
         */
        public Attendance GetById(int id)
        {
            return context.Attendances.FirstOrDefault(a => a.Id == id);
        }

        /**
         * <summary>Set the <c>DateTimeAttendanceStart</c> and <c>DateTimeAttendanceEnd</c> of an Attendance</summary>
         * <returns>Returns <c>false</c> if a error occured else <c>true</c></returns>
         */
        public bool Open(int id, DateTime startDateTime, DateTime endDateTime)
        {
            Attendance attendance = context.Attendances.Find(id);

            if (attendance == null)
            {
                return false;
            }

            if (attendance.DateTimeAttendanceStart != null)
            {
                return false;
            }

            if (startDateTime.CompareTo(endDateTime) > 0)
            {
                return false;
            }

            if (startDateTime.CompareTo(attendance.DateTimeLectureStart) < 0 ||
                endDateTime.CompareTo(attendance.DateTimeLectureEnd) > 0)
            {
                return false;
            }

            attendance.DateTimeAttendanceStart = startDateTime;

            attendance.DateTimeAttendanceEnd = endDateTime;

            context.Entry(attendance).State = EntityState.Modified;
            context.SaveChanges();
            return true;

        }

        /**
         * <summary>Set the <c>DateTimeAttendanceStart</c> and <c>DateTimeAttendanceEnd</c> of an Attendance</summary>
         * <returns>Returns <c>false</c> if a error occured else <c>true</c></returns>
         */
        public bool Open(int id, DateTime endDateTime)
        {
            return Open(id, DateTime.Now, endDateTime);
        }


        public bool Close(int id)
        {
            Attendance attendance = context.Attendances.Find(id);

            if (attendance == null)
            {
                return false;
            }

            if (!attendance.DateTimeAttendanceEnd.HasValue || attendance.DateTimeAttendanceEnd.Value.CompareTo(DateTime.Now) < 0)
            {
                return false;
            }

            attendance.DateTimeAttendanceEnd = DateTime.Now;

            context.Entry(attendance).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }


        /**
         * <summary>Remove <c>Attndanc</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Attendance o)
        {
            try
            {
                context.Entry(o).State = EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
