using System;

namespace HomeworkTask14 {
    
    class AppStart {
        
        static void Main() {

            string firstName = "Boyan";
            string middleName = "Lyubomirov";
            string lastName = "Hristov";
            ulong balance = 18446744073709551615;
            string bankName = "BankaDSKYaaaaa";
            string IBAN = "AL47212110090000000235698741";
            string BIC = "DEUTDEFF500";

            long creditCardNumberOne = 378282246310005;
            long creditCardNumberTwo = 378282246310004;
            long creditCardNumberThree = 378282246310003;

            Console.WriteLine("My variables are:\n {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n {8}\n {9}",
                firstName, middleName, lastName, balance, bankName, IBAN, BIC, creditCardNumberOne,
                creditCardNumberTwo, creditCardNumberThree);
        }
    }
}
