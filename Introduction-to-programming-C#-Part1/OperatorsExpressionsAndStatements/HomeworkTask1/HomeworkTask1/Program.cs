using System;

namespace HomeworkTask1 {
    class AppStart {
        static void Main() {

            int number;

            Console.Write("Enter an integer to see if it is odd or even: ");
            if (int.TryParse(Console.ReadLine(), out number)) { // If user enters a non-nummeric value code won't break

                if (number % 2 == 0) {
                    Console.WriteLine("The entered number is EVEN!");
                }
                else if (number % 2 != 0) {
                    Console.WriteLine("The entered number is ODD!");
                }
            }
                else {
                    Console.WriteLine("Invalid integer!");
                }
        }
    }
}
