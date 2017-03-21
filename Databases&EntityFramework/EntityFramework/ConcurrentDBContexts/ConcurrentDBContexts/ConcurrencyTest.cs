using System;
using System.Linq;

namespace ConcurrentDBContexts
{
    public class ConcurrencyTest
    {

        public static void PrintDBResult(NorthwindEntities context, string additionalMessage)
        {
            if (additionalMessage.Length > 0)
            {
                Console.WriteLine("\n{0}", additionalMessage);
            }

            Console.WriteLine("First user`s first name: {0}", context.Employees.First().FirstName);
        }

        public static void StartSecondConnection(NorthwindEntities connection1)
        {
            using (var connection2 = new NorthwindEntities())
            {
                PrintDBResult(connection2, "From connection 2's viewport, no savechanges on connection 1");
                connection2.Employees.First().FirstName = "Secondly";
                PrintDBResult(connection1, "FirstName changed from connection2 as well, this is connection1's viewport");
                
                connection1.SaveChanges();
                connection2.SaveChanges();

                PrintDBResult(connection1, "From view of connection 1 after both saveChanges executed");
                PrintDBResult(connection2, "From view of connection 2 after both saveChanges executed");
            }
        }

        public static void StartConnectionsChain()
        {
            using (var connection1 = new NorthwindEntities())
            {
                PrintDBResult(connection1, "First Connection, no changes");
                connection1.Employees.First().FirstName = "Firstly";
                StartSecondConnection(connection1);
            }
        }

        public static void Main()
        {
            StartConnectionsChain();

            using(var db = new NorthwindEntities()) {
                PrintDBResult(db, "Final state");
            }
            Console.WriteLine("\nConclusion: Use only db at moment, always fresh copy, single request, save and then delete.");
        }
    }
}
