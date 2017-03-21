namespace StudentSystem.ConsoleClient
{

    using System;
    using System.Linq;
    using StudentSystem.Database;
    using StudentSystem.Models;

    public class StudentSystemTest
    {
        public static void Main()
        {

            using (var db = new StudentSystemDbContext())
            {

                var returnedStudent = db.Students.FirstOrDefault(st => st.FirstName == "Boyan");

                Console.WriteLine("{0}: {1} {2} is {3} years old!",
                    returnedStudent.Id, returnedStudent.FirstName, returnedStudent.LastName, returnedStudent.Age);
            }

        }
    }
}
