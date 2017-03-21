using System;

namespace HomeworkTask7 {
    class AppStart {
        
        static void Main() {

            double sum, addNumber ;

            Console.WriteLine("Enter starting number to start adding values to it!");

            Console.Write("Starting Number: ");
            if (double.TryParse(Console.ReadLine(), out sum)) {

                Console.Write("Number to add: ");
                while (double.TryParse(Console.ReadLine(), out addNumber)) {

                    sum += addNumber;
                    Console.WriteLine("SUM: {0}", sum);
                    Console.Write("Number to add: ");
                }
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
