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

                o.Id = 0;
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Close(int id)
        {
            throw new NotImplementedException();
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
         * <summary>Check if <c>Attendance</c> is opened between two <c>DateTime</c></summary>
         * <returns>Returns <c>true</c> if opoened or <c>false</c> if not opened</returns>
         */
        public bool Open(int id, DateTime startDateTime, DateTime endDateTime)
        {
            Attendance attendance = context.Attendances.FirstOrDefault(a =>
                a.Id == id && DateTime.Compare(startDateTime, a.DateTimeAttendanceStart) < 0 &&
                DateTime.Compare(a.DateTimeAttendanceEnd, endDateTime) < 0);
            if (attendance == null)
            {
                return false;
            }
            return true;

        }

        /**
         * <summary>Check if <c>Attendance</c> is opened before given <c>DateTime</c></summary>
         * <returns>Returns <c>true</c> if opoened or <c>false</c> if not opened</returns>
         */
        public bool Open(int id, DateTime endDateTime)
        {
            Attendance attendance = context.Attendances.FirstOrDefault(a =>
                a.Id == id && DateTime.Compare(a.DateTimeAttendanceEnd, endDateTime) < 0);
            if (attendance == null)
            {
                return false;
            }

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
