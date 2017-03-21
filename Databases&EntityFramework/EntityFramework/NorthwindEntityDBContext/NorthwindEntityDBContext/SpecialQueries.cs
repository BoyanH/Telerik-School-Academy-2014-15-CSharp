using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEntityDBContext
{
    public class SpecialQueries
    {

        //-----------------------------------------------TASK 3 -------------------------------------------------

        public static List<Customer> GetCustomerWithSpecialOrderAndShipment(int orderYear, string shipmentTo)
        {
            using (var db = new NorthwindEntities())
            {
                var specialCustomers = db.Customers
                    .Where(customer => customer.Orders.Any(order => order.OrderDate.Value.Year == orderYear && order.ShipCountry == shipmentTo))
                    .ToList();

                return specialCustomers;
            }
        }

        //-----------------------------------------------TASK 5 -------------------------------------------------

        public static List<Order> GetSalesByPeriodAndRegion(DateTime startDate, DateTime endDate, string region)
        {
            using (var db = new NorthwindEntities())
            {
                var specialSales = db.Orders
                    .Where(
                            order => order.ShipRegion == region && 
                            DateTime.Compare(order.OrderDate.Value, startDate) >= 0 && 
                            DateTime.Compare(order.OrderDate.Value, endDate) <= 0
                          )
                    .ToList();

                return specialSales;
            }
        }
    }
}
