using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkTask9 {
    class AppStart {

        //Works strictly for 5 numbers ;/. If you don't want repetitive answers with integers with switched positions, you could
        //add another array with the subsets as ints and check for repetitions. I only check for repetitive strings.
        static List<string> getZeroSubsets(int[] args) {

            List<string> result = new List<string>();
            int[] availableArgs = args;

            for (int i = 0; i < args.Length; i++) {
                
                int crntArg = args[i];
                availableArgs = availableArgs.Where((val, idx) => idx != i).ToArray();

                foreach(int firstArg in availableArgs) {

                    int crntSum = crntArg + firstArg;

                    if (crntSum == 0) {

                        if (result.IndexOf(crntArg + " + " + firstArg + " = 0; ") == -1) {

                            result.Add(crntArg + " + " + firstArg + " = 0; ");
                        }
        
                        break;
                    }

                    foreach (int secondArg in availableArgs) {

                        if (secondArg != firstArg) {

                            crntSum += secondArg;

                            if (crntSum == 0) {

                                if (result.IndexOf(crntArg + " + " + firstArg + " + " + secondArg + " = 0; ") == -1) {

                                    result.Add(crntArg + " + " + firstArg + " + " + secondArg + " = 0; ");
                                }
                                break;
                            }

                            foreach (int thirdArg in availableArgs) {


                                if (thirdArg != secondArg && thirdArg != firstArg) {

                                    crntSum += thirdArg;

                                    if (crntSum == 0) {

                                        if (result.IndexOf(crntArg + " + " + firstArg + " + " + secondArg + " + " + thirdArg + " = 0; ") == -1) {

                                            result.Add(crntArg + " + " + firstArg + " + " + secondArg + " + " + thirdArg + " = 0; ");
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
        
        static void Main() {

            int numOne, numTwo, numThree, numFour, numFive;

            Console.WriteLine("Enter 5 numbers to get all the zero subsets.\n");

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

                Console.WriteLine("The count of zero subsets is: {0}. They are: ",
                    getZeroSubsets(new int[] { numOne, numTwo, numThree, numFour, numFive }).Count);

                foreach (string subset in getZeroSubsets(new int[] { numOne, numTwo, numThree, numFour, numFive })) {

                    Console.WriteLine(subset);
                }
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
