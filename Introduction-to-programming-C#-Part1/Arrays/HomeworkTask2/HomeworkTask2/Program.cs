using System;

namespace HomeworkTask2 {
    class AppStart {
        static void Main() {

            int[] arrayOne = new int[5],
                arrayTwo = new int[5];

            Console.WriteLine("Enter two arrays, each consisting of 5 integers to compare them element by element!\n\n");

            for (int i = 0; i < arrayOne.Length; i++) {

                Console.Write("arrayOne[{0}] = ", i);

                while (!int.TryParse(Console.ReadLine(), out arrayOne[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("arrayOne[{0}] = ", i);
                }
            }

            Console.WriteLine();

            for (int k = 0; k < arrayTwo.Length; k++) {

                Console.Write("arrayTwo[{0}] = ", k);

                while (!int.TryParse(Console.ReadLine(), out arrayTwo[k])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\narrayTwo[{0}] = ", k);
                }
            }

            Console.WriteLine();

            for (int z = 0; z < arrayOne.Length; z++) {

                char biggerOrSmaller;

                if (arrayOne[z] > arrayTwo[z]) {

                    biggerOrSmaller = '>';
                }
                else {
                    biggerOrSmaller = '<';
                }

                Console.WriteLine("arrayOne[{0}] {3} arrayTwo[{0}]; ==> {1} {3} {2}",
                        z, arrayOne[z], arrayTwo[z], biggerOrSmaller);
            }

            Console.WriteLine();
        }
    }
}
