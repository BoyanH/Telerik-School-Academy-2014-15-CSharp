using System;

namespace HomeworkTask7 {
    class AppStart {

        static bool isPrime(double number) {

            for (int i = 2; i < number; i++) {
                if (number % i == 0) {
                
                    return false;
                }
			}

            return true;

        }
        
        static void Main() {

            double number;

            Console.WriteLine("Write a number to see if it is prime!");
            Console.Write("Number: ");

            bool numberParsed = double.TryParse(Console.ReadLine(), out number);

            if (numberParsed) {

                if (isPrime(number)) {

                    Console.WriteLine("The number {0} is prime!", number);
                }
                else {
                    Console.WriteLine("The number {0} is not prime!", number);
                }
            }
        }
    }
}
