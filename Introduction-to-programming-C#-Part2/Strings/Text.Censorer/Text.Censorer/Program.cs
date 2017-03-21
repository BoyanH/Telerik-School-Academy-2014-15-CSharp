using System;

namespace Text.Censorer
{
    public class ReplaceForbiddenWords
    {

        public static string ReplaceWithAsterisks(string text, string[] forbWords)
        {

            string[] txtAsWordArr = text.Trim(new char[] { ',', '!', '.', '?' }).Split(' ');

            for (int word = 0; word < txtAsWordArr.Length; word++)
            {
                if (Array.IndexOf(forbWords, txtAsWordArr[word]) != -1)
                {
                    txtAsWordArr[word] = new string('*', txtAsWordArr[word].Length);
                }
            }

            return string.Join(" ", txtAsWordArr);
        }

        public static void Main()
        {

            Console.WriteLine("Enter a text and a list of comma-separated forbidden words to censor the text!\n");

            Console.Write("Text: ");
            string inputText = Console.ReadLine(); //Text remains as string in db
            Console.Write("Forbidden Words: ");
            //easier to keep forbWords as array in DB and be able to add, therefore our method works with string[]
            string[] forbWords = Console.ReadLine().Replace(" ", "").Split(new char[] { ',' });

            string censoredText = ReplaceWithAsterisks(inputText, forbWords);

            if (forbWords.Length > 0)
            {
                Console.WriteLine("{0}\nOutput: \n\n{1}", new string('-', 70), censoredText);
            }
            else
            {
                Console.WriteLine("Same as input!");
            }
        }
    }
}
