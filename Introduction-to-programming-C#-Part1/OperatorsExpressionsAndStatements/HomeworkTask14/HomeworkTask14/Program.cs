using System;

namespace HomeworkTask14 {
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

        //Must always be parsed int this manner: firstExchangeBit, secondExhangeBit; firstExchangeBit...
        static int changeManyBits(int number, int[] args) {

            int startNumber = number;

            for (int i = 0; i < args.Length; i+=2) {

                Console.WriteLine(args[i+1]);
                Console.WriteLine(startNumber);
                number = ModifyToHoldBitAtPos(number, args[i], FindBitAtGivenPos(startNumber, args[i + 1]));
                number = ModifyToHoldBitAtPos(number, args[i+1], FindBitAtGivenPos(startNumber, args[i]));
            }

            return number;
        }

        static void Main() {

            //Code works with a huge amount of bits, user won't really like to type them
            int number, bitOne, bitTwo, bitThree, bitFour, bitFive, bitSix;

            Console.WriteLine("Enter number and 6 bits to exchange 1 with 2, 3 with 4... etc. \n");

            Console.Write("Number: ");
            bool numberParsed = int.TryParse(Console.ReadLine(), out number);
            Console.Write("Bit one: ");
            bool bitOneParsed = int.TryParse(Console.ReadLine(), out bitOne);
            Console.Write("Bit two: ");
            bool bitTwoParsed = int.TryParse(Console.ReadLine(), out bitTwo);
            Console.Write("Bit three: ");
            bool bitThreeParsed = int.TryParse(Console.ReadLine(), out bitThree);
            Console.Write("Bit four: ");
            bool bitFourParsed = int.TryParse(Console.ReadLine(), out bitFour);
            Console.Write("Bit five: ");
            bool bitFiveParsed = int.TryParse(Console.ReadLine(), out bitFive);
            Console.Write("Bit six: ");
            bool bitSixParsed = int.TryParse(Console.ReadLine(), out bitSix);

            if (numberParsed && bitOneParsed && bitTwoParsed && bitThreeParsed && 
                bitFourParsed && bitFiveParsed && bitSixParsed) {

                Console.WriteLine("Result: {0}", changeManyBits(number, 
                    new int[] {bitOne, bitTwo, bitThree, bitFour, bitFive, bitSix}));

            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
