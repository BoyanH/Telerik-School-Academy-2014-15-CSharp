using System;
using System.Linq;
using System.Reflection;

namespace NorthwindEntityDBContext
{
    public class ADO
    {
        public static Customer AddCustomer(string contactName, string companyName, string address = null,
                                        string city = null, string region = null, string postCode = null,
                                        string country = null, string phone = null, string fax = null)
        {

            var newCustomer = new Customer()
            {
                CustomerID = "DSAD",
                CompanyName = companyName,
                ContactName = contactName,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            var result = new Customer();

            using (var db = new NorthwindEntities())
            {
                if (!ExistsInDB(db, newCustomer.ContactName))
                {
                    result = db.Customers.Add(newCustomer);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Such ContactName already exists!");
                }
            }

            return result;
        }

        public static Customer EditCustomer(Customer editedCustomer)
        {
            var crntCustomer = new Customer();

            using (var db = new NorthwindEntities())
            {

                if (!ExistsInDB(db, editedCustomer.CustomerID))
                {
                    crntCustomer = db.Customers.Where(c => c.CustomerID == editedCustomer.CustomerID).First();

                    foreach (var editedsProp in editedCustomer.GetType().GetProperties())
                    {
                        foreach (var crntsProp in crntCustomer.GetType().GetProperties())
                        {
                            if (crntsProp.Name == editedsProp.Name)
                            {
                                if (editedsProp.GetValue(editedCustomer, null) != null && editedsProp.Name != "CustomerID")
                                {
                                    crntsProp.SetValue(crntCustomer, editedsProp.GetValue(editedCustomer, null));
                                }
                            }
                        }
                    }
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("no such user");
                }
            }

            return crntCustomer;
        }

        public static Customer DeleteCustomer(Customer customer)
        {

            var result = new Customer();

            using (var db = new NorthwindEntities())
            {
                if (!ExistsInDB(db, customer.CustomerID))
                {
                    result = db.Customers.Remove(db.Customers.Where(c => c.CustomerID == customer.CustomerID).First());
                    db.SaveChanges();
                }
            }

            return result;
        }

        public static Customer GetCustomerByName(string name)
        {

            var result = new Customer();

            using (var db = new NorthwindEntities())
            {
                if (ExistsInDB(db, name))
                {
                    result = db.Customers.Where(c => c.ContactName == name).First();
                }
                else
                {
                    throw new Exception("customer not found");
                }
            }

            return result;
        }

        static bool ExistsInDB(NorthwindEntities db, string cname)
        {
            return db.Customers.Where(c => c.ContactName == cname).Any();
        }
    }
}
