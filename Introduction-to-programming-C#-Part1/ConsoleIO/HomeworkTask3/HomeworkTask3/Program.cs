using System;

namespace HomeworkTask3 {
    class AppStart {

        public class Manager {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string PhoneNumber { get; set; } //Although digits only, often begins with 0, which will dissapear in an int ;)
        }

        public class Company {

            public string Name { get; set; }
            public string Adress { get; set; }
            public string PhoneNumber { get; set; } //Although digits only, often begins with 0, which will dissapear in an int ;)
            public string FaxNumber { get; set; } //Although digits only, often begins with 0, which will dissapear in an int ;)
            public string WebSite { get; set; }

            public Manager Manager { get; set; }

            public override string ToString() {
                return "Company.ToString(): " + Name + " is suited on " + Adress +". Contact us anytime at " + PhoneNumber + 
                    ", using our fax (" + FaxNumber + ") or at our website " + WebSite + ". " +
                    "Our Manager, "+ Manager.FirstName + " " + Manager.LastName + ", is a " + 
                    Manager.Age + " year old professional. Call him anytime on " + Manager.PhoneNumber;
            }
        }

        static void Main() {

            int managerAge;

            Company theCompany = new Company();
            theCompany.Manager = new Manager();

            Console.Write("Company Name: ");
            theCompany.Name = Console.ReadLine();
            Console.Write("Company Adress: ");
            theCompany.Adress = Console.ReadLine();
            Console.Write("Company Phone Number: ");
            theCompany.PhoneNumber = Console.ReadLine();
            Console.Write("Company Fax Number: ");
            theCompany.FaxNumber = Console.ReadLine();
            Console.Write("Company Web site: ");
            theCompany.WebSite = Console.ReadLine();

            Console.Write("Company's Manager's First Name: ");
            theCompany.Manager.FirstName = Console.ReadLine();
            Console.Write("Company's Manager's Last Name: ");
            theCompany.Manager.LastName = Console.ReadLine();
            Console.Write("Company's Manager's Age: ");
            bool isManagerAgeParsed = int.TryParse(Console.ReadLine(), out managerAge);
            Console.Write("Company's Manager's Phone Number: ");
            theCompany.Manager.PhoneNumber = Console.ReadLine();

            if (isManagerAgeParsed) {
                theCompany.Manager.Age = managerAge;

                Console.WriteLine(theCompany.ToString());
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }



        }
    }
}
