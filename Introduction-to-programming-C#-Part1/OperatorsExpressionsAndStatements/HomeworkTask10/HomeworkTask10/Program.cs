using System;

namespace HomeworkTask10 {
    class AppStart {
        static bool IsBitAtPos(int number, int pos, int bit) {

            int i = 1;
            int numMask = i << pos;              //if pos is 2, then 1<<2 => 100 (all in binary)
            int numAndMask = numMask & number;  //if number is 4 (100 in binary) & 100 = 100

            return (numAndMask >> pos) == bit;           //100 >>2 => 1
            //Basically 1 << pos is always moving a "1" to the given position. Then it is & with the number,
            // so that "1" remains only if there is one "1" in the number. Then, when returned back to right,
            //we only have 1 or 0 (We are working with bits, but the returned value is still in decimal)
        }

        static void Main() {

            int givenInteger;
            int givenPos;

            Console.WriteLine("Enter an integer and position, to see if this integer's bit at given position is 1! \n");

            Console.Write("Integer: ");
            bool tryParseInteger = int.TryParse(Console.ReadLine(), out givenInteger);
            Console.Write("Position: ");
            bool tryParsePos = int.TryParse(Console.ReadLine(), out givenPos);

            if (tryParseInteger && tryParsePos) {

                Console.WriteLine(IsBitAtPos(givenInteger, givenPos, 1));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }


        }
    }
}
