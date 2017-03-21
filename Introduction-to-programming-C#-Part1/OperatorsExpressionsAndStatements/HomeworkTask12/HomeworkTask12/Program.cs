using System;

namespace HomeworkTask12 {
    class AppStart {

        static int ModifyToHoldBitAtPos(int number, int position, int value) {

            int mask;

            if (value == 0) {

                mask = ~(1 << position); // returns  1111111111111111111[0]11111111, where the 0 is at given pos
                number = number & mask;
            }
            else if (value == 1) {

                mask = 1 << position;
                number = number | mask;
            }
            else {

                Console.WriteLine("Invalid bit value!");
            }

            return number;
        }
        
        static void Main() {

            int number, position, value;

            Console.WriteLine("Enter number, position and value, to " + 
                "change the number's bit at given position with given value \n");

            Console.Write("Number: ");
            bool numberParsed = int.TryParse(Console.ReadLine(), out number);
            Console.Write("Position: ");
            bool positionParsed = int.TryParse(Console.ReadLine(), out position);
            Console.Write("Value: ");
            bool valueParsed = int.TryParse(Console.ReadLine(), out value);

            if (numberParsed && positionParsed && valueParsed) {

                Console.WriteLine("Result: {0}", ModifyToHoldBitAtPos(number, position, value));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
