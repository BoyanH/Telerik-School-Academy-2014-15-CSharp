using System;

namespace HomeworkTask1 {
    class AppStart {
        
        static void Main() {

            int firstNumber, secondNumber;

            Console.WriteLine("Enter two integers to change their values if the second one is bigger or else just display them! ;)\n");

            Console.Write("First Number: ");
            bool firstNumParsed = int.TryParse(Console.ReadLine(), out firstNumber);
            Console.Write("Second Number: ");
            bool secondNumParsed = int.TryParse(Console.ReadLine(), out secondNumber);

            if (firstNumParsed && secondNumParsed) {

                if (firstNumber > secondNumber) {

                    firstNumber += secondNumber;
                    secondNumber = firstNumber - secondNumber;
                    firstNumber = firstNumber - secondNumber;
                }

                Console.WriteLine("First Number: {0}\n Second Number: {1}", firstNumber, secondNumber);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
