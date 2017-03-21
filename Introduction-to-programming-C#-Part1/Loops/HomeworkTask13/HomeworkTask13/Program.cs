using System;
using System.Numerics;

namespace HomeworkTask13 {
    class AppStart {

        static BigInteger FindTrailingZeros(BigInteger number) {

            BigInteger result = 0;

            while (number % 10 == 0) {

                number /= 10;
                ++result;
            }

            return result;
        }

        static BigInteger FactorielOf(BigInteger n) {

            for (BigInteger i = n - 1; i > 0; i--) {

                n *= i;
            }

            return n;
        }

        static void Main() {

            BigInteger number, factorielOfNumber;

            Console.WriteLine("Enter an integer to find how many trailing zeros its factoriel has!\n");

            Console.Write("Number: ");
            bool numberParsed = BigInteger.TryParse(Console.ReadLine(), out number);

            if (numberParsed) {

                factorielOfNumber = FactorielOf(number);
                Console.WriteLine("Factoriel of Number: {0}", factorielOfNumber);
                Console.WriteLine("Trailing zeros of factoriel: {0}", FindTrailingZeros(factorielOfNumber));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }


        }
    }
}
