using System;
using System.Linq;

namespace Student.AnotherNameOrganiser
{
    public class OrganseInTwoWays
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
                    FirstName = "Stamat",
                    LastName = "Bojov",
                    Age = 14
                }
            };

            var queriedArrLinq =
                from student in studentsArr
                orderby student.FirstName descending, student.LastName descending
                select student;
            var queriedArrMethods = studentsArr
                .OrderByDescending(student => student.FirstName)
                .ThenByDescending(student => student.LastName);

            Console.WriteLine("Students unordered: \n{0}",
                string.Join(", \n", (object[])studentsArr));

            Console.WriteLine("Students ordered descending Linq: \n{0}",
                string.Join(", \n", queriedArrLinq));

            Console.WriteLine("Students ordered descending Methods: \n{0}",
                string.Join(", \n", queriedArrMethods));

        }
    }
}
