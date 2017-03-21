using System;

namespace HomeworkTask8 {
    class AppStart {

        static int FindGCD(int numberOne, int numberTwo) {

            int gcd = 1;
            int maxDivider = Math.Min(numberOne, numberTwo);

            for (int i = 1; i <= maxDivider; i++) {

                if (numberOne % i == 0 && numberTwo % i == 0) {

                    if (i > gcd) {

                        gcd = i;
                    }
                }
            }

            return gcd;
        }

        static void Main() {

            int firstNumber, secondNumber;

            Console.WriteLine("Enter 2 numbers to find their Greatest Common Divider! \n");

            Console.Write("First Number: ");
            bool firstParsed = int.TryParse(Console.ReadLine(), out firstNumber);
            Console.Write("Second Number: ");
            bool secondParsed = int.TryParse(Console.ReadLine(), out secondNumber);

            if (firstParsed && secondParsed) {

                Console.WriteLine("GCO from {0} and {1}: {2}", firstNumber, secondNumber, FindGCD(firstNumber, secondNumber));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
