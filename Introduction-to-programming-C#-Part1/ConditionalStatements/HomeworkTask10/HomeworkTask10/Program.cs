using System;

namespace HomeworkTask10 {
    class AppStart {
        
        static void Main() {

            int givenDigit;
            bool showScore = true;

            Console.WriteLine("Enter a digit to calculate your score!\n");

            Console.Write("Digit: ");
            bool digitParsed = int.TryParse(Console.ReadLine(), out givenDigit);

            if (digitParsed) {

                switch (givenDigit) {

                    case 0: Console.WriteLine("Score can't be 0!"); showScore = false; break;
                    case 1: givenDigit *= 10; break;
                    case 2: givenDigit *= 10; break;
                    case 3: givenDigit *= 10; break;
                    case 4: givenDigit *= 100; break;
                    case 5: givenDigit *= 100; break;
                    case 6: givenDigit *= 100; break;
                    case 7: givenDigit *= 1000; break;
                    case 8: givenDigit *= 1000; break;
                    case 9: givenDigit *= 1000; break;
                    default: Console.WriteLine("{0} is not a digit!", givenDigit); showScore = false; break;

                }

                if (showScore) {
                    Console.WriteLine("Your score is: {0}", givenDigit);
                }
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
