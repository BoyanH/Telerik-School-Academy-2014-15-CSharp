using System;

namespace HomeworkTask3 {
    class AppStart {
        
        static void Main() {

            int numOne, numTwo, numThree, biggest;

            Console.WriteLine("Enter three integers to find the biggest one! \n");

            Console.Write("First Integer: ");
            bool oneParsed = int.TryParse(Console.ReadLine(), out numOne);
            Console.Write("First Integer: ");
            bool twoParsed = int.TryParse(Console.ReadLine(), out numTwo);
            Console.Write("First Integer: ");
            bool threeParsed = int.TryParse(Console.ReadLine(), out numThree);

            if (oneParsed && twoParsed && threeParsed) {

                if (numOne > numTwo) {

                    if (numOne > numThree) {

                        biggest = numOne;
                    }
                    else {

                        biggest = numThree;
                    }
                }
                else {

                    if (numTwo > numThree) {

                        biggest = numTwo;
                    }
                    else {

                        biggest = numThree;
                    }
                }

                Console.WriteLine("Biggest int from the given three is: {0}", biggest);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
