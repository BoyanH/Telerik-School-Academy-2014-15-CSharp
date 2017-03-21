namespace EFQueryToListPerformance
{

    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;

    public class EFToListTest
    {
        public static void Main()
        {

            var slowQueryStopwatch = new Stopwatch();
            var optimizedQueryStopwatch = new Stopwatch();

            using (var db = new TelerikAcademyEntities())
            {

                slowQueryStopwatch.Start();

                var employeesWrongToListUseQuery = db.Employees.ToList()
                    .Select(employee => employee.Address).ToList()
                    .Select(address => address.Town).ToList()
                    .Where(town => town.Name == "Sofia")
                    .ToList();

                slowQueryStopwatch.Stop();
                optimizedQueryStopwatch.Start();

                var employeesOptimizedQuery = db.Employees
                    .Select(employee => employee.Address.Town)
                    .Where(town => town.Name == "Sofia")
                    .ToList();

                optimizedQueryStopwatch.Stop();

                Console.WriteLine("Query with many ToList calls estimated time: {0}", slowQueryStopwatch.Elapsed);
                Console.WriteLine("Optimized query estimated time: {0}", optimizedQueryStopwatch.Elapsed);
                Console.WriteLine("Optimized query is about {0:0} times faster!", 
                    slowQueryStopwatch.Elapsed.TotalMilliseconds / optimizedQueryStopwatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}
