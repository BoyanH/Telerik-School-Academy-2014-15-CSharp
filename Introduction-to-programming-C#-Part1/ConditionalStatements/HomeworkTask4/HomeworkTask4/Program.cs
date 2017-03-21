using System;

namespace HomeworkTask4 {
    class AppStart {
        
        static void Main() {

            int numOne, numTwo, numThree;

            Console.WriteLine("Enter three integers to find the biggest one! \n");

            Console.Write("First Integer: ");
            bool oneParsed = int.TryParse(Console.ReadLine(), out numOne);
            Console.Write("First Integer: ");
            bool twoParsed = int.TryParse(Console.ReadLine(), out numTwo);
            Console.Write("First Integer: ");
            bool threeParsed = int.TryParse(Console.ReadLine(), out numThree);

            if (oneParsed && twoParsed && threeParsed) {

                if (numOne < numTwo) {

                    numOne += numTwo;
                    numTwo = numOne - numTwo;
                    numOne = numOne - numTwo;
                }

                if (numOne < numThree) {

                    numOne += numThree;
                    numThree = numOne - numThree;
                    numOne = numOne - numThree;
                }

                if (numTwo < numThree) {

                    numTwo += numThree;
                    numThree = numTwo - numThree;
                    numTwo = numTwo - numThree;
                }

                Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}",
                            numOne, numTwo, numThree);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
