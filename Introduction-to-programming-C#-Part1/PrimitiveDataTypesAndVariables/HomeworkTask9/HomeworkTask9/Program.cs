using System;
using System.Text;

namespace HomeworkTask9 {
    
    class AppStart {

        static void PrintTriangle(int triangleLines, char givenChar, ConsoleColor color = ConsoleColor.Gray) {

            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = color;

            for (int line = 1; line < triangleLines + 1; line++) {

                int maxCharPos = 1 + (line-1)*2; // arithmetic progression, usually studied in 11th grade ;)

                for (int spaces = 0; spaces < triangleLines - line; spaces++) {
                    Console.Write(" ");
                }

                for (int charPos = 0; charPos < maxCharPos; charPos++) {

                    Console.Write(givenChar);
                }

                Console.WriteLine();
            }
        }

        static void Main() {

            char mychar = '\u00a9';

            Console.WriteLine("You can choose how many lines your triangle would have! :)");
            Console.WriteLine("Here is with three lines, or 9 chars, as the homework task was: ");
            PrintTriangle(3, mychar);

            Console.WriteLine("You can also pick character and color! :)");
            Console.WriteLine("And now here is a pure beauty! : ");
            PrintTriangle(15, '!', ConsoleColor.Yellow);
        }
    }
}
