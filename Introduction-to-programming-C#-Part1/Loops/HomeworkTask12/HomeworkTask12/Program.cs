using System;

namespace HomeworkTask12 {
    class AppStart {

        static void PrintMatrix(uint posInt) {

            Console.WriteLine();

            for (int i = 0; i < posInt; i++) {

                for (int j = 1; j <= posInt; j++) {

                    if (i + j < 10) {

                        Console.Write(" ");
                    }

                    Console.Write("{0} ", i + j);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine();
        }
        
        static void Main() {

            uint positiveInt;

            Console.WriteLine("Enter a POSITIVE INTEGER < 20 to print an according matrix!");

            Console.Write("Integer: ");
            bool posIntParsed = uint.TryParse(Console.ReadLine(), out positiveInt);

            if (posIntParsed && positiveInt < 20) {

                PrintMatrix(positiveInt);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
