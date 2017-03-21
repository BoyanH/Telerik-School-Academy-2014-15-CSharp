using System;

namespace HomeworkTask12 {
    class AppStart {
        static void Main() {

            for (int hex = 0; hex < 128; hex++) {

                char hexChar = (char)hex;

                Console.Write(hexChar);
                
                if (hex % 31 == 0 && hex != 0) { //For beauty, makes new line after each 31 char, separating
                                                // the table in 4 lines. They appear in 5, because one of the chars
                    Console.WriteLine();       //  Enter.
                }
            }
        }
    }
}
