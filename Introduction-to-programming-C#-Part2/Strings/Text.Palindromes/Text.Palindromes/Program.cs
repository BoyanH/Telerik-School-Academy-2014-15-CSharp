using System;
using System.Collections.Generic;
using System.Linq;

namespace Text.Palindromes
{
    public class FindPalindromes
    {

        static List<string> findPalindromesInText(string text)
        {

            string[] wordArray = text.Split(new char[] { ' ', '!', '?', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> palindromList = new List<string>();

            for (int word = 0; word < wordArray.Length; word++)
            {
                if (wordArray[word] == string.Join("", wordArray[word].ToCharArray().Reverse()))
                {
                    palindromList.Add(wordArray[word]);
                }
            }

            return palindromList;
        }

        public static void Main()
        {
            Console.WriteLine("Enter a text to find all palindromes in it!\n");
            Console.Write("Text: ");
            string inputText = Console.ReadLine();
            List<string> palindromesInText = findPalindromesInText(inputText);

            Console.WriteLine("Palindromes found: \n{0}\n", new string('-', 70));
            for (int pa = 0; pa < palindromesInText.Count; pa++)
            {
                Console.WriteLine(palindromesInText[pa]);
            }
            Console.WriteLine();

        }
    }
}
