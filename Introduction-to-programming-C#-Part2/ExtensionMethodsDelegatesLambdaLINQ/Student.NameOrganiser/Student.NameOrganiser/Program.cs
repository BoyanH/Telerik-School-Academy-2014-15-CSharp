using System;
using System.Linq;

namespace Student.NameOrganiser
{
    public class FNameBeforeLName
    {
        public static void Main()
        {

            var studentArr = new[] 
            {
                
                new
                {
                    FirstName = "Boyan",
                    LastName = "Hristov"
                },
                new
                {
                    FirstName = "Gosho",
                    LastName = "Peshov"
                },
                new
                {
                    FirstName = "Zvezdan",
                    LastName = "Yordanov"
                },
                new
                {
                    FirstName = "Divan",
                    LastName = "Zvezdev"
                },
                new
                {
                    FirstName = "Don",
                    LastName = "Cho"
                }
            };

            var queryiedStudents =
                from student in studentArr
                where String.Compare(student.FirstName, student.LastName) < 0
                select student;

            Console.WriteLine("All students: \n{0}", string.Join(", \n", (object[])studentArr));
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students, whose FirstName is before their LastName: \n{0}",
                string.Join(", \n", queryiedStudents));
        }
    }
}
