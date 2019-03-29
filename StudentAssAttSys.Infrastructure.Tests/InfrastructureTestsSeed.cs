using StudentAssAttSys.Core.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Infrastructure.Tests
{
    public static class InfrastructureTestsSeed
    {

        public static void SeedAll(StudentAssAttSysContext db)
        {
            SeedStudents(db);
            SeedLecturers(db);
            SeedModules(db);
            SeedModuleLinks(db);
            SeedAssessment(db);
        }

        public static void RemoveAll(StudentAssAttSysContext db)
        {
            RemoveAssessments(db);
            RemoveModules(db);
            RemoveStudents(db);
            RemoveLecturers(db);
        }

        public static void SeedStudents(StudentAssAttSysContext db)
        {
            db.Students.AddRange(new List<Student>()
            {
                new Student
                {
                    Id = "S80611",
                    User = new User
                    {
                        FirstName = "Joe",
                        LastName = "Test",
                        Email = "S80611@mail.itsligo.ie"
                    },
                    StudentNumber = "S80611",
                },
                new Student
                {
                    Id = "S47223",
                    User = new User
                    {
                        FirstName = "Brenda",
                        LastName = "Test",
                        Email = "S47223@mail.itsligo.ie"
                    },
                    StudentNumber = "S47223"
                }
            });
            db.SaveChanges();
        }

        public static void RemoveStudents(StudentAssAttSysContext db)
        {
            foreach (var student in db.Users.Where(u => u.Student != null))
            {
                db.Entry(student).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }

        public static void SeedLecturers(StudentAssAttSysContext db)
        {
            db.Lecturers.AddRange(new List<Lecturer>()
            {
                new Lecturer
                {
                    Id = "JLect",
                    User = new User
                    {
                        FirstName = "John",
                        LastName = "Test",
                        Email = "john.test@mail.itsligo.ie"
                    }
                },
                new Lecturer
                {
                    Id = "BLect",
                    User = new User
                    {
                        FirstName = "Bali",
                        LastName = "Test",
                        Email = "bali.test@mail.itsligo.ie"
                    }
                }
            });
            db.SaveChanges();
        }

        public static void RemoveLecturers(StudentAssAttSysContext db)
        {
            foreach (var lectuer in db.Users.Where(u => u.Lecturer != null))
            {
                db.Entry(lectuer).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }

        public static void SeedModules(StudentAssAttSysContext db)
        {
            db.Modules.AddRange(new List<Module>()
            {
                new Module
                {
                    Name = "Module 1",
                    GPAPercentage = 20.0
                },
                new Module
                {
                    Name = "Module 2",
                    GPAPercentage = 50.0
                }
            });
            db.SaveChanges();
        }

        public static void RemoveModules(StudentAssAttSysContext db)
        {
            foreach (var module in db.Modules)
            {
                db.Entry(module).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }

        public static void SeedModuleLinks(StudentAssAttSysContext db)
        {
            Module[] modules = db.Modules.ToArray();
            int n = 1;
            foreach (Module module in modules)
            {
                if (module.Lecturers == null)
                {
                    module.Lecturers = new List<Lecturer>();
                }

                if (module.Students == null)
                {
                    module.Students = new List<Student>();
                }

                if (n == 1)
                {
                    module.Lecturers.AddRange(db.Lecturers.ToList());
                    module.Students.AddRange(db.Students.ToList());
                }
                else
                {
                    module.Lecturers.Add(db.Lecturers.FirstOrDefault());
                    module.Students.Add(db.Students.FirstOrDefault());
                }
                db.Entry(module).State = EntityState.Modified;
                n++;
            }


            db.SaveChanges();
        }

        public static void SeedAssessment(StudentAssAttSysContext db)
        {
            db.Assessments.AddRange(new List<Assessment>()
            {
                new Assessment
                {
                    DateTimeStart = DateTime.Now.AddHours(-1),
                    DateTimeEnd = DateTime.Now.AddHours(1),
                    LecturerId = db.Lecturers.FirstOrDefault().Id,
                    ModuleId = db.Modules.FirstOrDefault().Id
                },
                new Assessment
                {
                    DateTimeStart = DateTime.Now.AddHours(-1),
                    DateTimeEnd = DateTime.Now.AddHours(1),
                    LecturerId = db.Lecturers.FirstOrDefault().Id,
                    ModuleId = db.Modules.FirstOrDefault().Id
                }
            });
            db.SaveChanges();
        }

        public static void RemoveAssessments(StudentAssAttSysContext db)
        {
            foreach (var assessment in db.Assessments)
            {
                db.Entry(assessment).State = EntityState.Deleted;
            }

            db.SaveChanges();
        }
    }
}
