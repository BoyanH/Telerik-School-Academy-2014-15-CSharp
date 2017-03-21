using System;

namespace HomeworkTask1 {
    class AppStart {

        static void PrintToN(int n) {

            for (int i = 0; i < n; i++) {

                Console.WriteLine(i+1);
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
