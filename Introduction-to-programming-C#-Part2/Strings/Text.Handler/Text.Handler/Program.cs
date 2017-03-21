using System;
using System.Collections.Generic;

namespace Text.Handler
{

    public class ExtractSentencesWithWord
    {

        public static string[] SentenceArray(string text)
        {

            return text.Split(new Char[] { '.', '!', '?' });
        }

        public static string[][] WordArray(string[] sentenceArray)
        {

            string[][] wordsInSentences = new string[sentenceArray.Length][];

            for (int i = 0; i < sentenceArray.Length; i++)
            {

                wordsInSentences[i] = sentenceArray[i].Split(new char[] { ' ', ',' });
            }

            return wordsInSentences;
        }

        public static List<string[]> ReturnSentancesWithWord(string[][] wordArray, string inputWord)
        {

            List<string[]> resultList = new List<string[]>();

            for (int i = 0; i < wordArray.GetLength(0); i++)
            {

                for (int z = 0; z < wordArray[i].Length; z++)
                {

                    if (string.Compare(inputWord, wordArray[i][z], true) == 0)
                    {

                        resultList.Add(wordArray[i]);
                        break;
                    }
                }
            }

            return resultList;
        }

        public static void Main()
        {

            Console.Write("Text: ");
            string userInputText = Console.ReadLine();
            Console.Write("Search for word: ");
            string inputWord = Console.ReadLine();

            string[] sentenceArray = SentenceArray(userInputText);
            string[][] wordArray = WordArray(sentenceArray);
            List<string[]> finalSentances = ReturnSentancesWithWord(wordArray, inputWord);

            for (int sentance = 0; sentance < finalSentances.Count; sentance++)
            {

                Console.WriteLine("Found sentence with \"{0}\": {1}.",
                    inputWord, String.Join(" ", finalSentances[sentance]));
            }

        }
    }
}