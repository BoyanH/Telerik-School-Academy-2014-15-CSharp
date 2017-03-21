using System;
using System.Linq;

namespace HomeworkTask9 {
    class AppStart {

        static int[] MostCommon(int[] numbers) {

            int crntCounter = 0,
                maxCounter = 0,
                maxElement = 0;

            for (int i = 0; i < numbers.Length; i++){

                crntCounter = 0;
			 
                for (int k = 0; k < numbers.Length; k++) {

                    if (numbers[i] == numbers[k]) {

                        crntCounter++;
                    }

                    if (crntCounter > maxCounter) {

                        maxCounter = crntCounter;
                        maxElement = numbers[i];
                    }
			    }
			}

            int[] mostCommon = new int[maxCounter];

            for (int z = 0; z < maxCounter; z++) {

                mostCommon[z] = maxElement;
            }

            return mostCommon;
        }

        static void Main() {

            int n;

            Console.WriteLine("Enter: N - Length; To find the most common integer in the array!\n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.WriteLine("N: ");
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

            int[] mostCommon = MostCommon(givenIntArray);

            Console.WriteLine("The most common out of {0} elements is: {1}({2} times)!", 
                n, mostCommon[0], mostCommon.Length);
        }
    }
}