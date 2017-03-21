using System;

namespace NorthwindEntityDBContext
{
    class EFLinqQueries
    {
        static void Main()
        {
            var me = ADO.AddCustomer("Boyan", "Unfortunately None");

            var boyan = ADO.GetCustomerByName("Boyan");
            Console.WriteLine("Added customer: ContactName: {0}, CompanyName: {1}",
                                me.ContactName, me.CompanyName);

            me.Country = "Bulgaria";
            var updatedMe = ADO.EditCustomer(me);

            boyan = ADO.GetCustomerByName("Boyan");
            Console.WriteLine("Changed country! Customer's Country: {0}", boyan.Country);
            
            ADO.DeleteCustomer(me);
            try
            {
                boyan = ADO.GetCustomerByName("Boyan");
                Console.WriteLine("Customer's name: {0}", boyan.ContactName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




            //------------------------------------------TASK 3 ------------------------------------------------

            Console.WriteLine("Shipment in 1997 to Canada: ");
            foreach (var customer in SpecialQueries.GetCustomerWithSpecialOrderAndShipment(1997, "Canada"))
            {
                Console.WriteLine("    {0}", customer.ContactName);
            }


            //------------------------------------------TASK 5 ------------------------------------------------
            
            Console.WriteLine("Orders between 1996 and 1997 in SP: ");
            foreach (var order in SpecialQueries.GetSalesByPeriodAndRegion(new DateTime(1996, 3, 2, 12, 12, 21), new DateTime(1997, 3, 2, 12, 12, 21), "SP"))
            {
                Console.WriteLine("    {0}", order.ShipName);
            }

        }
    }
}