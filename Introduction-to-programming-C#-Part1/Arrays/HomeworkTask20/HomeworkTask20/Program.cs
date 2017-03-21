using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask20 {
    class AppStart {

        static List<int[]> variationsList = new List<int[]>();

        static void Variations(int[] arr, int index, int n) {
            
            if (index == arr.Length) {

                //Using a List and Cloning the arr every time in order not to change, we can keep track of all variations
                variationsList.Add((int[]) arr.Clone());
            }
            else {
                
                for (int i = 1; i <= n; i++) {
            
                    arr[index] = i;
                    Variations(arr, index + 1, n);
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

            int[] variations = new int[k];
            Variations(variations, 0, n);

            for (int i = 0; i < variationsList.Count; i++) {

                Console.WriteLine(string.Join(", ", variationsList[i]));
            }
        }
    }
}
