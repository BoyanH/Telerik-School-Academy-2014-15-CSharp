using System;
using System.Linq;

namespace HomeworkTask12 {
    class AppStart {

        static int IndexOfUsingBinary(char value, char[] arr) {

            value = Char.ToUpper(value);

            int lower = 0,
                upper = arr.Length - 1,
                middle = (upper + lower) / 2;

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

            string word;
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Console.WriteLine("Enter a word to print the index of each letter in the alphabet!\n");

            Console.Write("Word: ");
            word = Console.ReadLine().ToString();

            for (int i = 0; i < 26; i++) {
                

            }

            char[] wordCharArray = word.ToCharArray();
            int[] indexes = new int[wordCharArray.Length];

            for (int k = 0; k < wordCharArray.Length; k++) {

                indexes[k] = IndexOfUsingBinary(wordCharArray[k], alphabet);
            }

            char openCurly = '{',
                 closeCurly = '}';

            Console.WriteLine("Indexes in the word \"{0}\": \n{1}{2}{3}", 
                word, openCurly, string.Join(", ", indexes), closeCurly);
        }
    }
}
