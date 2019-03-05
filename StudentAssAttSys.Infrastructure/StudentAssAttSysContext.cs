namespace StudentAssAttSys.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentAssAttSys.Core.Core;

    public class StudentAssAttSysContext : DbContext
    {
        // Your context has been configured to use a 'StudentAssAttSysContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentAssAttSys.Infrastructure.StudentAssAttSysContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentAssAttSysContext' 
        // connection string in the application configuration file.
        public StudentAssAttSysContext()
            : base("name=StudentAssAttSysContext")
        {
            //Configuring DbContext
            this.Configuration.LazyLoadingEnabled = false;

            //Create DatabaseIfNotExist Initializer
            Database.SetInitializer<StudentAssAttSysContext>(new DropCreateDatabaseIfModelChanges<StudentAssAttSysContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<ClassGroup> ClassGroups { get; set; }
        public virtual DbSet<Comment> Comments  { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Result> Results { get; set; }

    }
}