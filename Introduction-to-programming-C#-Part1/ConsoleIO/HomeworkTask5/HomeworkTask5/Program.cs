using System;

namespace HomeworkTask5 {
    
    class AppStart {
        
        static void Main() {

            int firstNumber, secondNumber;

            Console.WriteLine("Enter two integers to see the bigger one!");

            Console.Write("First Integer: ");
            bool firstParsed = int.TryParse(Console.ReadLine(), out firstNumber);
            Console.WriteLine("Second Integer: ");
            bool secondParsed = int.TryParse(Console.ReadLine(), out secondNumber);

            if (firstParsed && secondParsed) {

                Console.WriteLine("The bigger number from {0} and {1} is {2}!", 
                                    firstNumber, secondNumber, Math.Max(firstNumber, secondNumber));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
