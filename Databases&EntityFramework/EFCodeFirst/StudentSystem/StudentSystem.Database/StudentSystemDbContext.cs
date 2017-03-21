namespace StudentSystem.Database
{

    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Database.Migrations;

    public class StudentSystemDbContext : DbContext
    {

        public StudentSystemDbContext()
            : base("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }


        public IDbSet<Course> Courses { get; set; }


        public IDbSet<Homework> Homeworks { get; set; }
    }
}
