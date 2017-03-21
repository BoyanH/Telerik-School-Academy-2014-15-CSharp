namespace NPlusOneQueryProblemAndInclude
{

    using System;
    using System.Diagnostics;
    using System.Linq;

    public class EFIncludeTest
    {
        public static void Main()
        {

            //-----------QUERY WITHOUT INCLUDE, N+1 QUERY PROBLEM
            Stopwatch queryWithoutIncludeElapsedTime = new Stopwatch();

            queryWithoutIncludeElapsedTime.Start();

            using (var db = new TelerikAcademyEntities())
            {
                foreach (var employee in db.Employees)
                {
                    //using Write so I can later print result too without overfilling the console, 
                    //data itself is not important, I am reseearching performance
                    Console.Write("{0}, {1}, {2}; ", 
                        employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
                }
            }

            queryWithoutIncludeElapsedTime.Stop();
            Console.WriteLine("\n{0}\nFirst query without Include elapsed time: {1}\n{0}\n", 
                new string('-', 70), queryWithoutIncludeElapsedTime.Elapsed);

            //----------------------------------QUERY USING INCLUDE
            Stopwatch queryWithIncludeElapsedTime = new Stopwatch();

            queryWithIncludeElapsedTime.Start();

            using (var db = new TelerikAcademyEntities())
            {
                foreach (var employee in db.Employees.Include("Address").Include("Department"))
                {
                    Console.Write("{0}, {1}, {2}; ", 
                        employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
                }
            }

            queryWithIncludeElapsedTime.Stop();
            Console.WriteLine("\n{0}\nSecond query using Include elapsed time: {1}\n{0}\n",
                new string('-', 70), queryWithIncludeElapsedTime.Elapsed);

            Console.WriteLine("\n{0}\nWith Include query is about {1:0} times faster!\n{0}\n",
                new string('-', 70),
                queryWithoutIncludeElapsedTime.Elapsed.TotalMilliseconds / queryWithIncludeElapsedTime.Elapsed.TotalMilliseconds);
        }
    }
}
