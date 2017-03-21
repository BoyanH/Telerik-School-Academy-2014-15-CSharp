using System;

namespace HomeworkTask11 {
    class AppStart {

        static string NumberInEnglish(int number) {

            string hunderds = "", decimals = "", ones = "", numberInEnglish = "";

            //[X]XX
            switch (number / 100 | 0) {

                case 0: hunderds = ""; break;
                case 1: hunderds = "One Hundred And "; break;
                case 2: hunderds = "Two Hundred And "; break;
                case 3: hunderds = "Three Hundred And "; break;
                case 4: hunderds = "Four Hundred And "; break;
                case 5: hunderds = "Five Hundred And "; break;
                case 6: hunderds = "Six Hundred And "; break;
                case 7: hunderds = "Seven Hundred And "; break;
                case 8: hunderds = "Eight Hundred And "; break;
                case 9: hunderds = "Nine Hundred And "; break;
                default: hunderds = ""; break;

            }

            //X[X]X
            if ((number / 10 | 0) % 10 != 1) {

                switch ((number / 10 | 0) % 10) {

                    case 0: decimals = ""; break;
                    case 2: decimals = "Twenty "; break;
                    case 3: decimals = "Thirty "; break;
                    case 4: decimals = "Fourty "; break;
                    case 5: decimals = "Fifty "; break;
                    case 6: decimals = "Sixty "; break;
                    case 7: decimals = "Seventy "; break;
                    case 8: decimals = "Eighty "; break;
                    case 9: decimals = "Ninety "; break;
                }

                //XX[X] for not-teens
                switch (number % 10) {

                    case 0: ones = ""; break;
                    case 1: ones = "One"; break;
                    case 2: ones = "Two"; break;
                    case 3: ones = "Three"; break;
                    case 4: ones = "Four"; break;
                    case 5: ones = "Five"; break;
                    case 6: ones = "Six"; break;
                    case 7: ones = "Seven"; break;
                    case 8: ones = "Eight"; break;
                    case 9: ones = "Nine"; break;
                    default: ones = ""; break;
                }
            }
            else {

                //XX[X] for teens
                switch (number % 10) {

                    case 0: decimals = "Ten"; ones = ""; break;
                    case 1: decimals = "Eleven"; ones = ""; break;
                    case 2: decimals = "Twelve"; ones = ""; break;
                    case 3: decimals = "Thirteen"; ones = ""; break;
                    case 4: decimals = "Fourteen"; ones = ""; break;
                    case 5: decimals = "Fifteen"; ones = ""; break;
                    case 6: decimals = "Sixteen"; ones = ""; break;
                    case 7: decimals = "Seventeen"; ones = ""; break;
                    case 8: decimals = "Eighteen"; ones = ""; break;
                    case 9: decimals = "Nineteen"; ones = ""; break;
                    default: decimals = ""; ones = ""; break;
                }
            }

            numberInEnglish = hunderds + decimals + ones;

            return numberInEnglish;
        }

        static void RepetitiveTranslation() {

            int number;
            bool intParsed = false;

            do {

                Console.Write("Integer: ");
                intParsed = int.TryParse(Console.ReadLine(), out number);

                if (!intParsed) {

                    Console.WriteLine("Invalid Integer!");
                }
                else if (number >999 || number < 0) {

                    Console.WriteLine("Must be in range 0-999! Try Again!");
                    intParsed = false;
                }
            }
            while (!intParsed);

            Console.WriteLine("{0} in english: {1}", number, NumberInEnglish(number));
        }
        
        static void Main() {

            Console.WriteLine("Enter an integer to see its english-word equivalent! ;)\n");

            while (true) {

                RepetitiveTranslation();
            }
        }
    }
}
