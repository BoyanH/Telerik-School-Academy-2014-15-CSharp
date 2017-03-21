using System;

namespace HomeworkTask4 {
    class AppStart {

        static double NFactDevidedByKFact(double n, double k) {

            for (int i = Convert.ToInt16(n) - 1; i > 0; i--) {
                
                n *= i;
            }

            for (int j = Convert.ToInt16(k) - 1; j > 0; j--) {

                k *= j;
            }

            return n / k;
        }

        static void Main() {

            int n, k;

            Console.WriteLine("Enter N and K to find N!/K! \n");

            Console.Write("N: ");
            bool nParsed = int.TryParse(Console.ReadLine(), out n);
            Console.Write("K: ");
            bool kParsed = int.TryParse(Console.ReadLine(), out k);

            if (nParsed && kParsed) {

                Console.WriteLine("{0}! / {1}! = {2}", n, k, NFactDevidedByKFact(n, k));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
