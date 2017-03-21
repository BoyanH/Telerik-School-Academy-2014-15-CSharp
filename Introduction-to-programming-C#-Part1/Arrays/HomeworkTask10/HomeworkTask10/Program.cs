using System;
using System.Linq;

namespace HomeworkTask10 {
    class AppStart {

        static int[] FindSumSequence(int[] numbers, int sum) {

            int crntSum;

            for (int i = 0; i < numbers.Length; i++) {

                crntSum = numbers[i];

                if (crntSum == sum) {

                    int[] sequence = new int[1];
                    sequence[0] = numbers[i];

                    return sequence;
                }

                for (int k = i+1; k < numbers.Length; k++) {

                    crntSum += numbers[k];

                    if (crntSum == sum) {
                        Console.WriteLine("yey");
                        int[] sequence = new int[k-i+1];

                        for (int z = 0; z < sequence.Length; z++) {

                            sequence[z] = numbers[i + z];
                        }

                        return sequence;
                    }
                }
            }

            return new int[0];
        }

        static void Main() {

            int n, sum;

            Console.WriteLine("Enter: N - Length; Sum; To find the sequence in an array that creates the sum!\n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.WriteLine("\nN: ");
            }

            Console.Write("Sum: ");
            while (!int.TryParse(Console.ReadLine(), out sum)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\nSum: ");
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

            int[] sumSequence = FindSumSequence(givenIntArray, sum);
            char openCurly = '{',
                 closeCurly = '}';

            Console.WriteLine("If there is a sequence, that sums to {0}, it sure is the following one!:\n {1}{2}{3}",
                sum, openCurly, string.Join(", ", sumSequence), closeCurly);
        }
    }
}