using System;

namespace Dictionary
{
    public class Word
    {

        public static string Explain(string word)
        {
            string[] dictionary = {
                ".NET - platform for applications from Microsoft",
                "CLR - managed execution environment for .NET",
                "namespace - hierarchical organization of classes"
            };
            string foundExplanation = "";

            foreach(string explanation in dictionary) 
            {

                int dashIndex = explanation.IndexOf('-');
                string crntDictWord = explanation.Substring(0, dashIndex - 1);

                if (crntDictWord == word)
                {
                    foundExplanation = explanation.Substring(dashIndex + 2);
                }
            }

            return foundExplanation;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Enter a word from our dictionary (.NET, CLR, namespace) to find its explanation!\n");
            Console.Write("Word: ");
            string inputWord = Console.ReadLine();
            string explanation = Explain(inputWord);

            Console.WriteLine("Explanation: {0}", explanation);
        }
    }
}
