using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask21 {
    class AppStart {

        static List<int[]> combinationsList = new List<int[]>();

        static void Combinations(int[] arr, int index, int n) {

            if (index == arr.Length) {

                int counterOfRepetitions = 0;
                int maxCounter = 0;

                for (int z = 0; z < arr.Length; z++) {    

                    for (int q = 0; q < arr.Length; q++) {

                        if (arr[z] == arr[q]) {

                            counterOfRepetitions++;
                        }
                    }

                    if (counterOfRepetitions > maxCounter) {

                        maxCounter = counterOfRepetitions;
                    }

                    counterOfRepetitions = 0;
                }

                if (maxCounter < 2) {
                    //Using a List and Cloning the arr every time in order not to change, we can keep track of all combinations
                    combinationsList.Add((int[])arr.Clone());
                }
            }
            else {

                for (int i = 1; i <= n; i++) {

                    arr[index] = i;
                    Combinations(arr, index + 1, n);
                }
            }
        }

        static void Main() {

            int n, k;

            Console.WriteLine("N - set 1 to N; K - Set length/Combination length! Enter and check for yoursel! ;)\n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\nN: ");
            }

            Console.Write("K: ");
            while (!int.TryParse(Console.ReadLine(), out k)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\nK: ");
            }

            int[] combinations = new int[k];
            Combinations(combinations, 0, n);

            for (int i = 0; i < combinationsList.Count; i++) {

                Console.WriteLine(string.Join(", ", combinationsList[i]));
            }
        }
    }
}
