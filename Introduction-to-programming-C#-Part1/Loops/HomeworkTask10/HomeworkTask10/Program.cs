using System;

namespace HomeworkTask10 {
    class AppStart {

        static int FactorielOf(int n) {

            if (n == 0) {

                return 1;
            }

            for (int i = n - 1; i > 0; i--) {

                n *= i;
            }

            return n;
        }

        static int FindCatalanNumber(int n) {

            return FactorielOf(2 * n) / (FactorielOf(n + 1) * FactorielOf(n));
        }

        static void Main() {

            int nth;

            Console.WriteLine("Enter an integer N, to find the Nth Catalan Number! :) \n");

            Console.Write("N: ");
            bool nthParsed = int.TryParse(Console.ReadLine(), out nth);

            if (nthParsed) {

                Console.WriteLine("The {0} Catalan Number is: {1}", nth, FindCatalanNumber(nth));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
