using System;

namespace HomeworkTask4 {
    
    class AppStart {

        static int[] FindBiggestSequence(int[] givenArray) {

            int counter = 1,
                maxCounter = 1,
                maxSequence = givenArray[0],
                crntSequence;
        
            for (int i = 1; i < givenArray.Length; i++) {
			 
                if(givenArray[i] == givenArray[i-1]) {
                
                    ++counter;

                    crntSequence = givenArray[i];

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
			 
                biggestSequence[indx] = maxSequence;
			}

            return biggestSequence;
        }
        
        static void Main() {

            int[] intArray = new int[10];

            Console.WriteLine("Enter 10 integers of an array to find the biggest sequence of equal numbers!\n");

            for (int i = 0; i < intArray.Length; i++) {

                Console.Write("intArray[{0}] = ", i);
                
                while(!int.TryParse(Console.ReadLine(), out intArray[i])) {

                    Console.WriteLine("Invalid Integer!");
                    Console.Write("\nintArray[{0}] = ", i);
                }
            }

            int[] biggestSequence = FindBiggestSequence(intArray);

            Console.WriteLine("Biggest sequence consists of {0} times the number '{1}'!",
                biggestSequence.Length, biggestSequence[0]);
        }
    }
}
