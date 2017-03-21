using System;

namespace HomeworkTask5 {
    class AppStart {

        static void Main() {

            int digit;
            string digitEnglish;

            Console.WriteLine("Write a digit to see its english word equivalent! :)");

            Console.Write("Digit: ");
            bool digitParsed = int.TryParse(Console.ReadLine(), out digit);

            if (digitParsed) {

                switch (digit) {

                    case 0: digitEnglish = "Zero"; break;
                    case 1: digitEnglish = "One"; break;
                    case 2: digitEnglish = "Two"; break;
                    case 3: digitEnglish = "Three"; break;
                    case 4: digitEnglish = "Four"; break;
                    case 5: digitEnglish = "Five"; break;
                    case 6: digitEnglish = "Six"; break;
                    case 7: digitEnglish = "Seven"; break;
                    case 8: digitEnglish = "Eight"; break;
                    case 9: digitEnglish = "Nine"; break;
                    default: digitEnglish = "No such digit!"; break;
                }

                Console.WriteLine("The digit {0} in english is: {1}", digit, digitEnglish);
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
