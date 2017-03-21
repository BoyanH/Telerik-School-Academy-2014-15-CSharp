namespace StudentSystem.Database.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Database.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            this.seedStudents(context);
            this.seedCourses(context);
            this.extendBasicStudents(context);
        }

        private void extendBasicStudents(StudentSystemDbContext context)
        {
            Student boco =
                (
                    from student in context.Students
                    where student.FirstName == "Boyan" && student.LastName == "Hristov" && student.Age == 18
                    select student
                ).FirstOrDefault();

            var csharpCourse = context.Courses.First(course => course.Name == "C#");

            if (! (boco.Courses.Any() && boco.Homeworks.Any() ))
            {

                boco.Courses.Add(csharpCourse);
                boco.Courses.Add(context.Courses.First(course => course.Name == "Javascript"));

                boco.Homeworks.Add(new Homework()
                {
                    TimeSent = DateTime.Now,
                    Course = csharpCourse,
                    Content = "MEGA CONTENT",
                    FilePath = "../bestHomework.rar"
                });

                context.SaveChanges();
            }
        }

        private void seedCourses(StudentSystemDbContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddOrUpdate(
                    new Course()
                    {
                        Name = "C#",
                        Location = "Telerik School Academy",
                        StartDate = (DateTime)new DateTime(2014, 10, 14)
                    },
                    new Course()
                    {
                        Name = "Javascript",
                        Location = "Telerik School Academy",
                        StartDate = (DateTime)new DateTime(2013, 11, 3),
                        EndDate = (DateTime)new DateTime(2014, 6, 22)
                    }
                );

                context.SaveChanges();
            }
        }

        private void seedStudents(StudentSystemDbContext context)
        {

            if (!context.Students.Any())
            {
                context.Students.AddOrUpdate(
                    new Student()
                    {
                        FirstName = "Boyan",
                        LastName = "Hristov",
                        Age = 18
                    },
                    new Student()
                    {
                        FirstName = "Nedelcho",
                        LastName = "Petrov",
                        Age = 18
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
