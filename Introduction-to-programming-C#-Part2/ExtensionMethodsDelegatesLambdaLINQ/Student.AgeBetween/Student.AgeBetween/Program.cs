using System;
using System.Linq;

namespace Student.AgeBetween
{
    public class Between18And24
    {
        public static void Main()
        {
            var studentsArr = new[]
            {
                new 
                {
                    FirstName = "Pesho",
                    LastName = "Goshov",
                    Age = 19
                },
                new 
                {
                    FirstName = "Divan",
                    LastName = "Zvezdev",
                    Age = 32
                },
                new 
                {
                    FirstName = "Don",
                    LastName = "Cho",
                    Age = 24
                },
                new 
                {
                    FirstName = "Boyan",
                    LastName = "Hristov",
                    Age = 18
                },
                new 
                {
                    FirstName = "Stamat",
                    LastName = "Petrov",
                    Age = 25
                },
                new 
                {
                    FirstName = "Bojo",
                    LastName = "Bojov",
                    Age = 14
                }
            };

            var queriedStudents =
                from student in studentsArr
                where student.Age >= 18 && student.Age <= 24
                select student;

            Console.WriteLine("All Students are: \n{0}",
                string.Join(", \n", (object[])studentsArr));
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students with age between 18 and 24 are: \n{0}",
                string.Join(", \n", queriedStudents));
        }
    }
}
