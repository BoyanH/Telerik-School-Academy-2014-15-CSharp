using System;

namespace HomeworkTask4 {
    class AppStart {
        
        static void Main(string[] args) {

            uint firstNumber, secondNumber, divider;
            uint count = 0;

            Console.WriteLine("Enter two numbers and a division number, to see how many numbers between the give two " +
                                "can be divided by the divider with no ramainer! ;)");

            Console.Write("First Number: ");
            bool firstParsed = uint.TryParse(Console.ReadLine(), out firstNumber);
            Console.Write("Second Number: ");
            bool secondParsed = uint.TryParse(Console.ReadLine(), out secondNumber);
            Console.Write("Divider: ");
            bool dividerParsed = uint.TryParse(Console.ReadLine(), out divider);

            if (firstParsed && secondParsed && dividerParsed) {

                for (uint i = firstNumber; i < secondNumber + 1; i++) {

                    if (i % divider == 0) {

                        count++;
                    }
                }

                Console.WriteLine("The count of numbers between {0} and {1} inclusively, that can be divided by {2} " +
                                    "with no remainder is {3}", firstNumber, secondNumber, divider, count);
            }
            else {

                Console.WriteLine("Invalid Integer! Must be >= 0!");
            }
        }
    }
}
