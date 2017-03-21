using System;

namespace HomeworkTask6 {
    class AppStart {

        static double StrangeSum(double n, double x) {

            double result = 0;

            for (int nthIndx = 0; nthIndx <= n; nthIndx++) {

                result += FactorielOf(nthIndx) / Math.Pow(x, nthIndx);
            }

            return result;
        }

        static int FactorielOf(int n) {

            if (n == 0) {

                return 1;
            }

            for (int i = n - 1; i > 0; i--) {

                n *= i;
            }

            return n;
        }

        static void Main() {

            double n, x;

            Console.WriteLine("Enter N and X to find the sum of 1 + 1!/X + 2!/X2 + … + N!/XN \n");

            Console.Write("N: ");
            bool nParsed = double.TryParse(Console.ReadLine(), out n);
            Console.Write("X: ");
            bool xParsed = double.TryParse(Console.ReadLine(), out x);

            if (nParsed && xParsed) {

                Console.WriteLine("1 + 1!/{1} + 2!/{1}^2 + … + {0}!/{1}^{0}  = {2}", n, x, StrangeSum(n, x));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}