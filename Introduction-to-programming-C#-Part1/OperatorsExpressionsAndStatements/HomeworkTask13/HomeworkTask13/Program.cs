using System;

namespace HomeworkTask13 {
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

        static int FindBitAtGivenPos(int number, int bitNumber) {

            int mask = 1 << bitNumber; //if for example bitNumber = 2, mask = 100
            number = (number & mask) >> bitNumber; // if number = 5, [1]01 & [1]00, number = 100 >> 2 => 1

            return number;
        }

        static void Main() {

            int number;

            Console.WriteLine("Enter number, to exchange its 3th, 4th and 5th bit " +
                "with its 24th, 25th and 26th bit \n");

            Console.Write("Number: ");
            bool numberParsed = int.TryParse(Console.ReadLine(), out number);

            if (numberParsed) {

                int bitAtPos3 = FindBitAtGivenPos(number, 3);
                int bitAtPos4 = FindBitAtGivenPos(number, 4);
                int bitAtPos5 = FindBitAtGivenPos(number, 5);
                int bitAtPos24 = FindBitAtGivenPos(number, 24);
                int bitAtPos25 = FindBitAtGivenPos(number, 25);
                int bitAtPos26 = FindBitAtGivenPos(number, 26);

                int numberWithExchanged3Pos = ModifyToHoldBitAtPos(number, 3, bitAtPos24);
                numberWithExchanged3Pos = ModifyToHoldBitAtPos(numberWithExchanged3Pos, 24, bitAtPos3);

                int numberWithExchanged4Pos = ModifyToHoldBitAtPos(numberWithExchanged3Pos, 4, bitAtPos25);
                numberWithExchanged4Pos = ModifyToHoldBitAtPos(numberWithExchanged4Pos, 25, bitAtPos4);

                int numberWithExchanged5Pos = ModifyToHoldBitAtPos(numberWithExchanged4Pos, 5, bitAtPos26);
                numberWithExchanged5Pos = ModifyToHoldBitAtPos(numberWithExchanged5Pos, 26, bitAtPos5);

                Console.WriteLine("Result: {0}", numberWithExchanged5Pos);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
