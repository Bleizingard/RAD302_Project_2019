﻿using StudentAssAttSys.Core.Core;
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
                User user = o.User;
                user.Id = o.Id;

                user.Student = new Student
                {
                    StudentNumber = o.StudentNumber
                };

                context.Entry(user).State = EntityState.Added;
                context.SaveChanges();
                return o.Id;
            }
            catch (Exception ex)
            {
                return "";
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
                student.Attendances = o.Attendances;
                student.User.Comments = o.User.Comments;
                student.User.Email = o.User.Email;
                student.User.FirstName = o.User.FirstName;
                student.User.LastName = o.User.LastName;
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
            return context.Students.Include(s => s.User).ToArray();
        }

        /**
         * <summary>Get <c>Student</c> from the database</summary>
         * <returns>Returns a <c>Student</c> or <c>null</c> if nothing found</returns>
         */
        public Student GetById(string id)
        {
            return context.Students.Include(s => s.User).FirstOrDefault(s => s.Id == id);
        }

        /**
         * <summary>Remove <c>Student</c> from the database</summary>
         * <returns>Returns <c>true</c> if succeed else false</returns>
         */
        public bool Remove(Student o)
        {
            try
            {
                User user = context.Users.FirstOrDefault(u => u.Id.Equals(o.Id));

                context.Entry(user.Student).State = EntityState.Deleted;
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
