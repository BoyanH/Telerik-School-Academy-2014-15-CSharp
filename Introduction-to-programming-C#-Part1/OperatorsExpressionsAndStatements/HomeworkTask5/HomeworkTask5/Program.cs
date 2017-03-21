using System;

namespace HomeworkTask5 {
    
    class AppStart {

        static int IsBitOneOrNull(int number, int pos) {

            int i = 1;
            int numMask = i << pos;              //if pos is 2, then 1<<2 => 100 (all in binary)
            int numAndMask = numMask & number;  //if number is 4 (100 in binary) & 100 = 100
            
            return numAndMask >> pos;           //100 >>2 => 1
            //Basically 1 << pos is always moving a "1" to the given position. Then it is & with the number,
            // so that "1" remains only if there is one "1" in the number. Then, when returned back to right,
            //we only have 1 or 0 (We are working with bits, but the returned value is still in decimal)
        }

        static void Main() {

            int givenInteger;
            int givenBit;

            Console.WriteLine("Enter an integer and bit, to see if this integer's bit is 1 or 0! \n");

            Console.Write("Integer: ");
            bool tryParseInteger = int.TryParse(Console.ReadLine(), out givenInteger);
            Console.Write("Bit: ");
            bool tryParseBit = int.TryParse(Console.ReadLine(), out givenBit);

            if (tryParseInteger && tryParseBit) {

                    int oneOrNull = IsBitOneOrNull(givenInteger, givenBit);
                    Console.WriteLine(oneOrNull);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }

            
        }
    }
}
