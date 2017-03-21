using System;
using System.Collections.Generic;

namespace HomeworkTask7 {
    class AppStart {

        static int SumOfNFibonaccis(int n) {

            int fibonacciNumber = 0,
                sum = 0;
            List<int> arrayOfFibonaccis = new List<int>();

            for (int i = 0; i < n; i++) {

                if (i == 1) {

                    fibonacciNumber = 1;
                }
                else if (i != 1 && i != 0) {

                    fibonacciNumber += arrayOfFibonaccis[i-2];
                }

                sum += fibonacciNumber;
                arrayOfFibonaccis.Add(fibonacciNumber);
            }

            return sum;
        }

        static void Main() {

            int n;

            Console.WriteLine("Enter N to find the sum of the firt N fibonacci numbers! \n");

            Console.Write("N: ");
            bool nParsed = int.TryParse(Console.ReadLine(), out n);

            if (nParsed) {

                Console.WriteLine("Sum of first {0} fibonacci numbers = {1}", n, SumOfNFibonaccis(n));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}