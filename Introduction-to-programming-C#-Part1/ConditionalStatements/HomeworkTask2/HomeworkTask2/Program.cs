using System;

namespace HomeworkTask2 {
    class AppStart {

        static void Main() {

            int numOne, numTwo, numThree,
                minuses = 0;
            char sign;

            Console.WriteLine("Enter three integer to see the sign of their product with no calculations! ;)");

            Console.Write("First Integer: ");
            bool oneParsed = int.TryParse(Console.ReadLine(), out numOne);
            Console.Write("First Integer: ");
            bool twoParsed = int.TryParse(Console.ReadLine(), out numTwo);
            Console.Write("First Integer: ");
            bool threeParsed = int.TryParse(Console.ReadLine(), out numThree);

            if (oneParsed && twoParsed && threeParsed) {
                if (numOne < 0) {

                    ++minuses;
                }
                if (numTwo < 0) {

                    ++minuses;
                }
                if (numThree < 0) {

                    ++minuses;
                }

                if (minuses == 1 || minuses == 3) {

                    sign = '-';
                }
                else {
                    sign = '+';
                }

                Console.WriteLine("The sign of the product is: {0}", sign);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
