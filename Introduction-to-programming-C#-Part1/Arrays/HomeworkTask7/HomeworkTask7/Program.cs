using System;
using System.Linq;

namespace HomeworkTask7 {
    class AppStart {

        static int[] SortArray(int[] arr) {

            int smallestElem = 0,
                smallestElemPos = 0;

            for (int indx = 0; indx < arr.Length; indx++) {
                
                smallestElem = arr[indx];
                smallestElemPos = indx;

                for (int i = indx; i < arr.Length; i++) {

                    if (arr[i] < smallestElem) {

                        smallestElem = arr[i];
                        smallestElemPos = i;
                    }
                }

                int elemToBeSwapped = arr[indx];
                arr[indx] = smallestElem;
                arr[smallestElemPos] = elemToBeSwapped;
            }
            

            

            return arr;
        }
        
        static void Main() {

            int[] array = new int[10];

            Console.WriteLine("Enter an array to sort it in increasing order!\n");

            for (int i = 0; i < array.Length; i++) {

                Console.Write("array[{0}] = ", i);
                while (!int.TryParse(Console.ReadLine(), out array[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\narray[{0}] = ", i);
                }
            }

            array = SortArray(array);
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
