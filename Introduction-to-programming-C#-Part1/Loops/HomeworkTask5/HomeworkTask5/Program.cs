using System;

namespace HomeworkTask5 {
    class AppStart {

        static double StrangeFactorielOperations(double n, double k) {

            double kMinusN = k - n;

            for (int i = Convert.ToInt16(n) - 1; i > 0; i--) {

                n *= i;
            }

            for (int j = Convert.ToInt16(k) - 1; j > 0; j--) {

                k *= j;
            }

            Console.WriteLine(kMinusN);

            for (int z = Convert.ToInt16(kMinusN) - 1; z > 0; z--) {
                
                kMinusN *= z;
            }

            return n*k/kMinusN;
        }

        static void Main() {

            uint n, k;

            Console.WriteLine("Enter N and K, both > 1 and k > n, to find N!*K! / (K-N)!  \n");

            Console.Write("N: ");
            bool nParsed = uint.TryParse(Console.ReadLine(), out n);
            Console.Write("K: ");
            bool kParsed = uint.TryParse(Console.ReadLine(), out k);

            if (nParsed && kParsed && n > 1 && k > 1 && k > n) {

                Console.WriteLine("{0}!*{1}! / ({1}-{0})!  = {2}", n, k, StrangeFactorielOperations(n, k));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
