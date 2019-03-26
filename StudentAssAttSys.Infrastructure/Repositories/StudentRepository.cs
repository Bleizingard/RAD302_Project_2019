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
    public class StudentRepository : IGenericRepository<Student, string>
    {
        private StudentAssAttSysContext context { get; set; }

        public StudentRepository()
        {
            context = new StudentAssAttSysContext();
        }

        /**
         * <summary>Add <c>Student</c> in the database</summary>
         * <returns>Returns the <c>ID</c> of the new Student or <c>"-1"</c>(string) if it fails</returns>
         */
        public string Add(Student o)
        {
            try
            {
                context.Entry(o).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }

        /**
         * <summary>Edit <c>Student</c> in the database</summary>
         * <returns>Returns <c>true</c> if succeed or <c>false</c> if it fails</returns>
         */
        public bool Edit(Student o)
        {
            Student student = GetById(o.Id);
            if (student == null)
            {
                return false;
            }

            try
            {
                student.StudentNumber = o.StudentNumber;
                student.Id = o.Id;
                student.Assessments = o.Assessments;
                student.Attendances = o.Attendances;
                student.Comments = o.Comments;
                student.Email = o.Email;
                student.FirstName = o.FirstName;
                student.LastName = o.LastName;
                student.Modules = o.Modules;

                context.Entry(student).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * <summary>Get all <c>Students</c> from the database</summary>
         * <returns>Returns an array of all students</returns>
         */
        public Student[] GetAll()
        {
            return context.Students.ToArray();
        }

        /**
         * <summary>Get <c>Student</c> from the database</summary>
         * <returns>Returns a <c>Student</c> or <c>null</c> if nothing found</returns>
         */
        public Student GetById(string id)
        {
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        /**
         * <summary>Remove <c>Student</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Student o)
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
