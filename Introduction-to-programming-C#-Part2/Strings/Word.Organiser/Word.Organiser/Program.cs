using System;

namespace Word.Organiser
{
    public class OrganiseWords
    {
        static string orderWordList(string wordList)
        {
            string[] wordListArr = wordList.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(wordListArr);

            return string.Join(" ", wordListArr);
        }

        public static void Main()
        {
            Console.WriteLine("Enter a word list, separated by spaces to order it!");
            string inputWordList = Console.ReadLine();
            Console.WriteLine("Ordered list: \n{0}\n{1}\n", new string('-', 70), orderWordList(inputWordList));
        }
    }
}
