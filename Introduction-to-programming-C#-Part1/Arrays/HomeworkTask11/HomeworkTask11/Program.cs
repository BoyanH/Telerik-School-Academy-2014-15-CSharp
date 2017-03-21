using System;
using System.Linq;

namespace HomeworkTask11 {
    class AppStart {

        static int IndexOfUsingBinary(int value, int[] arr) {

            int lower = 0,
                upper = arr.Length - 1,
                middle = (upper+lower)/2;

            Array.Sort(arr);

            while (lower <= upper) {

                if (arr[middle] == value) {

                    return middle;
                }
                else if (arr[middle] < value) {

                    lower = middle + 1;
                }
                else if (arr[middle] > value) {

                    upper = middle - 1;
                }

                middle = (upper + lower) / 2;
            }
            

            return -1;
        }

        static void Main() {

            int n, value;

            Console.WriteLine("Enter N = Length of Array, Value = Value to search for and array, " +
                "to find the index of the value in the given array!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NOTE THAT FOR BINARY SEARCH ARRAY IS FIRST SORTED! IF YOU PASS UNSORTED ARRAY, INDEX WILL BE WRONG!\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\n N: ");
            }

            Console.Write("Value: ");
            while (!int.TryParse(Console.ReadLine(), out value)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\n Value: ");
            }

            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++) {

                Console.Write("array[{0}]: ", i);
                while (!int.TryParse(Console.ReadLine(), out array[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\narray[{0}]: ", i);
                }
            }

            Console.WriteLine("Index of {0} in the given array is {1}!", value, IndexOfUsingBinary(value, array));
        }
    }
}
