using System;
using System.Linq;

namespace HomeworkTask6 {
   
    class AppStart {

        static int[] BiggestSumOf(int[] numbers, int k) {

            int lastIndex = numbers.Length - 1;
            int[] biggestSum = new int[k];

            Array.Sort(numbers);

            for (int i = 0; i < k; i++) {

                biggestSum[i] = numbers[lastIndex - i];
            }

            return biggestSum;
        }

        static void Main() {

            int n, k;

            Console.WriteLine("Enter: N - Length of Array; K - amount of array's elements to find biggest sum out of!\n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.WriteLine("N: ");
            }
            Console.Write("K: ");
            while (!int.TryParse(Console.ReadLine(), out k)) {

                Console.WriteLine("Invalid Integer!");
                Console.WriteLine("K: ");
            }

            int[] givenIntArray = new int[n];
            Console.WriteLine();

            for (int i = 0; i < n; i++) {
                
                Console.Write("givenIntArray[{0}] = ", i);
                while (!int.TryParse(Console.ReadLine(), out givenIntArray[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\ngivenIntArray[{0}] = ", i);
                }
            }

            int[] biggestSum = BiggestSumOf(givenIntArray, k);
            char openCurly = '{',
                 closeCurly = '}';

            Console.WriteLine("The biggest sum of {0} elements in the array is {1}! Here is the combination: \n {2}{3}{4}",
                k, biggestSum.Sum(), openCurly, string.Join(", ", biggestSum.Select(v => v.ToString())), closeCurly);
        }
    }
}