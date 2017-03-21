using System;

namespace HomeworkTask7 {
    class AppStart {

        static int FindGreatest(int[] args) {

            int greatest = args[0];

            for (int i = 0; i < args.Length; i++) {

                if (args[i] > greatest) {

                    greatest = args[i];
                }

            }

            return greatest;
        }
        
        static void Main() {

            int numOne, numTwo, numThree, numFour, numFive;

            Console.WriteLine("Enter 5 integers to get the biggest one!\n");

            Console.Write("Integer One: ");
            bool oneParsed = int.TryParse(Console.ReadLine(), out numOne);
            Console.Write("Integer Two: ");
            bool twoParsed = int.TryParse(Console.ReadLine(), out numTwo);
            Console.Write("Integer Three: ");
            bool threeParsed = int.TryParse(Console.ReadLine(), out numThree);
            Console.Write("Integer Four: ");
            bool fourParsed = int.TryParse(Console.ReadLine(), out numFour);
            Console.Write("Integer Five: ");
            bool fiveParsed = int.TryParse(Console.ReadLine(), out numFive);

            if (oneParsed && twoParsed && threeParsed && fourParsed && fiveParsed) {

                Console.WriteLine("The greatest int of all five is: {0}", 
                    FindGreatest(new int[] {numOne, numTwo, numThree, numFour, numFive}));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
