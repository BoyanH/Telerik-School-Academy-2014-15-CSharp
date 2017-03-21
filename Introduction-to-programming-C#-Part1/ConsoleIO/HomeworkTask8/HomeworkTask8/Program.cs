using System;

namespace HomeworkTask8 {
    class AppStart {
        
        static void Main() {

            int number;

            Console.WriteLine("Enter a number to print all the number is the interval [1 ;your number]");
            Console.Write("Your Number: ");

            if (int.TryParse(Console.ReadLine(), out number)) {

                Console.WriteLine();
                for (int i = 1; i <= number; i++) {

                    Console.WriteLine(i);
                }
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
