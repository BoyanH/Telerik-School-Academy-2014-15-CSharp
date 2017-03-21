using System;

namespace HomeworkTask2 {
    class AppStart {

        static void PrintToN(int n) {

            for (int i = 1; i <= n; i++) {

                if (!(!(i % 3 != 0) && !(i % 7 != 0))) {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main() {

            int n;
            bool nParsed = false;

            Console.WriteLine("Enter an integer to print all the numbers from 1 to it! ;)\n");

            do {

                Console.Write("Integer (N): ");
                nParsed = int.TryParse(Console.ReadLine(), out n);

                if (!nParsed) {

                    Console.WriteLine("Invalid Integer!");
                }
            }
            while (!nParsed);

            PrintToN(n);


        }
    }
}
