using System;
using System.Text;

namespace Sentence.Editor
{
    public class WordManipulator
    {

        public static string ReverseWords(string sentence)
        {

            StringBuilder sb = new StringBuilder();

            string[] wordArray = sentence.Split(new char[] { '!', '.', ',', ' ', }, StringSplitOptions.RemoveEmptyEntries);
            string[] signArray = sentence.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                '+', '#', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                                                'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                                                'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', ')', '(',
                                                '*', '/', '=', '~', '`' }, StringSplitOptions.RemoveEmptyEntries);
            for (int word = 0; word < wordArray.Length; word++)
            {

                sb.Append(string.Format("{0}{1}", wordArray[wordArray.Length - word - 1], signArray[word]));
            }

            return sb.ToString();
        }

        public static void Main()
        {

            Console.WriteLine("Enter a sentence to reverse its words!\n");

            Console.Write("Sentence: ");
            string sentence = Console.ReadLine();
            string reversedSentence = ReverseWords(sentence);

            Console.WriteLine("\nOutput: \n{0}", reversedSentence);
        }
    }
}
