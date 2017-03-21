using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Transactions; 

namespace NorthwindOrderTransactions
{
    public class OrderTransactionsTest
    {

        public static int AddOrderTransaction(Order newOrder)
        {

            int affectedRows = 0;

            using (var db = new NorthwindEntities())
            {
                using (var scope = new TransactionScope())
                {

                    var objectContext = ((IObjectContextAdapter)db).ObjectContext;

                    db.Orders.Add(newOrder);

                    affectedRows = objectContext.SaveChanges(false);

                    //if we get everything is executed fine, no rollback.
                    //  else => no AcceptAllChanges() called, which is same as Rollback (I suppose)
                    scope.Complete();
                    objectContext.AcceptAllChanges();
                }
            }

            return affectedRows;
        }

        public static void Main()
        {
            var newOrder = new Order() { ShipName="Titanik" };
            
            var rowsAdded = AddOrderTransaction(newOrder);
            Console.WriteLine("{0} {1} added to Orders table in NorthwindEntities!", 
                rowsAdded, rowsAdded > 1 ? "rows" : "row");

        }
    }
}
