using System;

namespace HomeworkTask6 {
    
    class AppStart {

        static void PrintGender(bool isFemale) {

            if (!isFemale) {

                Console.WriteLine("Cheers, mate!");
            }
                else {

                    Console.WriteLine("Oh, you are a beautiful creature!");
                }
        }

        static void AskUser() {
        
            Console.WriteLine("How about you? Type \"yes\" for female and \"no\" for male!");

            string consoleAnswer = Console.ReadLine();

            if (consoleAnswer == "yes") {
                PrintGender(true);
            }
            else if (consoleAnswer == "no") {
                PrintGender(false);
            }
                else {
                    Console.WriteLine("I think even you have no idea what you are!");
                    AskUser();
                }
        }

        static void Main() {
            
            bool isFemale = false;
            Console.WriteLine("The essential question today is, what gender is everybody! So starting with me, am I a female?");
            PrintGender(isFemale);
            
            AskUser();
        }
    }
}
