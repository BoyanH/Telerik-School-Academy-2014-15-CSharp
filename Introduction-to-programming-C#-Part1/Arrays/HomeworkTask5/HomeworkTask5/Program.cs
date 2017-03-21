using System;
using System.Linq;

namespace HomeworkTask5 {
    
    class AppStart {

        static int[] FindBiggestSequence(int[] givenArray) {

            int counter = 1, //count of crnt sequence's members
                maxCounter = 1, //count of max sequence's memeber
                maxSequence = givenArray[0], //start of max sequence
                crntSequence = givenArray[0]; //start of crnt sequence

            for (int i = 1; i < givenArray.Length; i++) {

                if (givenArray[i] == givenArray[i - 1] + 1) {

                    //2nd number of a new sequence
                    if (counter == 1) {

                        //the start of the sequence
                        crntSequence = givenArray[i - 1];
                    }

                    ++counter;

                    if (counter > maxCounter) {

                        maxCounter = counter;
                        maxSequence = crntSequence;
                    }

                }
                else {

                    counter = 1;
                    crntSequence = givenArray[i];
                }
            }

            int[] biggestSequence = new int[maxCounter];

            for (int indx = 0; indx < maxCounter; indx++) {

                biggestSequence[indx] = maxSequence + indx;
            }

            return biggestSequence;
        }

        static void Main() {

            int[] intArray = new int[10];

            Console.WriteLine("Enter 10 integers of an array to find the biggest sequence of equal numbers!\n");

            for (int i = 0; i < intArray.Length; i++) {

                Console.Write("intArray[{0}] = ", i);

                while (!int.TryParse(Console.ReadLine(), out intArray[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\nintArray[{0}] = ", i);
                }
            }

            int[] biggestSequence = FindBiggestSequence(intArray);

            char openCurly = '{';
            char closeCurly = '}';
            Console.WriteLine("\nBiggest sequence consists of {0} elements: \n {1}{2}{3}\n",
                biggestSequence.Length, openCurly,string.Join(", ", biggestSequence.Select(v => v.ToString())), closeCurly);
        }
    }
}
