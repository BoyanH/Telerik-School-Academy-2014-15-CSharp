using System;
using System.Collections.Generic;

namespace HomeworkTask3 {
    class Program {
        static void Main() {

            bool stillPassing = true;
            List<long> numbersArray = new List<long>();
            string newConsoleLine;
            long maxValue;

            Console.WriteLine("Enter a sequence of integers and \"stop\" when you are ready, to print the biggest number!\n");

            do {

                long newLong;

                Console.Write("New Integer (or \"stop\" to finish): ");
                newConsoleLine = Console.ReadLine();

                if (newConsoleLine != "stop") {

                    if (long.TryParse(newConsoleLine, out newLong)) {

                        numbersArray.Add(newLong);
                    }
                    else {

                        Console.WriteLine("Invalid Integer! 'Number' was not added!");
                    }
                }
                else {

                    stillPassing = false;
                }
                
            }
            while (stillPassing);

            if (numbersArray.Count > 0) {

                maxValue = numbersArray[0];
                for (int i = 0; i < numbersArray.Count; i++) {

                    if (numbersArray[i] > maxValue) {

                        maxValue = numbersArray[i];
                    }
                }

                Console.WriteLine("\nMax value: {0}", maxValue);
            }
            else {

                Console.WriteLine("No added numbers to find max from!");
            }
        
        }
    }
}
