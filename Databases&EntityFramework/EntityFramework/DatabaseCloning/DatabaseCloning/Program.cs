using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCloning
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This program will automatically clone Northwind in Northwintwin, if you have it, of course! ;)");
            using (var db = new NorthwindEntities())
            {
                DBCloner.CloneDb(db);
            }
        }
    }
}
