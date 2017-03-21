using System;

namespace HomeworkTask2 {
    class AppStart {
        static void Main() {

            int number;

            Console.Write("Enter an integer to see if it is odd or even: ");
            if (int.TryParse(Console.ReadLine(), out number)) { // If user enters a non-nummeric value code won't break

                if (number%5==0 && number%7==0) {
                    Console.WriteLine("The entered number CAN be divided by 5 and 7 at the same time! :)");
                }
                else if (number%5==0) {
                    Console.WriteLine("The number CAN'T be divided by 7!");
                }
                else if (number % 7 == 0) {
                    Console.WriteLine("The number CAN'T be divided by 5!");
                }
                    else {
                        
                        Console.WriteLine("The number CAN'T be divided by both 5 and 7!");
                    }
            }
            else {
                Console.WriteLine("Invalid integer!");
            }
        }
    }
}
