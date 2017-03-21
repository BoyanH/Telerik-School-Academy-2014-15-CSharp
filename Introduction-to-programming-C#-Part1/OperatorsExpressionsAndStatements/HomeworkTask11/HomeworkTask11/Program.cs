using System;

namespace HomeworkTask11 {
    class AppStart {

        static int ExtractBitsFromInt(int number, int bitNumber) {

            int mask = 1 << bitNumber; //if for example bitNumber = 2, mask = 100
            number = (number & mask) >> bitNumber; // if number = 5, [1]01 & [1]00, number = 100 >> 2 => 1

            return number;
        }

        static void Main() {



            Console.WriteLine(ExtractBitsFromInt(5, 2));
        }
    }
}
