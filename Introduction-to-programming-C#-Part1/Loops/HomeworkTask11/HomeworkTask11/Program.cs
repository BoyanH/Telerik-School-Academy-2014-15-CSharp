using System;

namespace HomeworkTask11 {
    class AppStart {

        static void PrintAllCardsFromType(string card) {

            char hearts = '\x03';  //♥
            char diamonds = '\x04';  //♦
            char clubs = '\x05';  //♣
            char spades = '\x06';  //♠

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}{2} of hearts; {1}{2} of diamonds; \n", hearts, diamonds, card);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}{2} of clubs; {1}{2} of spades;\n", clubs, spades, card);

            Console.WriteLine();
        }

        static void Main() {

            for (int i = 2; i < 14; i++) {

                if (i >= 10) {

                    switch (i) {

                        case 10: PrintAllCardsFromType("J - Jack"); break;
                        case 11: PrintAllCardsFromType("Q - Queen"); break;
                        case 12: PrintAllCardsFromType("K - King"); break;
                        case 13: PrintAllCardsFromType("A - Ace"); break;
                        default: PrintAllCardsFromType("S - Something"); break;

                    }
                }
                else {

                    PrintAllCardsFromType(i.ToString());
                }
            }

        }
    }
}
