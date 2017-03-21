using System;

namespace HomeworkTask1 {
    class AppStart {
        
        static void Main() {

            int intOne, intTwo, intThree;

            Console.WriteLine("Write 3 integers to get their sum! \n");

            Console.Write("Integer 1: ");
            bool intOneParsed = int.TryParse(Console.ReadLine(), out intOne);
            Console.Write("Integer 2: ");
            bool intTwoParsed = int.TryParse(Console.ReadLine(), out intTwo);
            Console.Write("Integer 3: ");
            bool intThreeParsed = int.TryParse(Console.ReadLine(), out intThree);

            if (intOneParsed && intTwoParsed && intThreeParsed) {

                Console.WriteLine("Sum: {0}", intOne + intTwo + intThree);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
