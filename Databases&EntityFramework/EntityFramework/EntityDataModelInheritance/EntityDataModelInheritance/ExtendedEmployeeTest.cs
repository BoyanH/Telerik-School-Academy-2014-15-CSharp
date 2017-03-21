using System;
using System.Linq;

namespace EntityDataModelInheritance
{
    public class ExtendedEmployeeTest
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                foreach (var employee in db.Employees)
                {
                    //check class ExtendedEmployee
                    var territories = employee.CorrespondingTerritories.Select(ct => ct.TerritoryDescription.Trim());

                    Console.WriteLine("\nI am {0} {1} and my corresponding territories are: \n    {2}",
                        employee.FirstName, employee.LastName, string.Join(", ", territories));
                }
            }

        }
    }
}
