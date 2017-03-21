using System;

namespace Text.Substring
{
    class FindSubstringCount
    {
        public static void Main()
        {

            Console.WriteLine("Enter a text and a substring to find out how many times the substring is found in the text!\n");
            
            Console.Write("Text: ");
            string text = Console.ReadLine();
            Console.Write("Substring: ");
            string input = Console.ReadLine();

            int count = 0, n = 0;

            while ((n = text.ToLower().IndexOf(input.ToLower(), n) + 1) != 0) //IndexOf is case sensitive
            {                                                       //important to call ToLower()/ToUpper() on both searched wod and text
                count++;
            }

            Console.WriteLine("Occurances: {0}", count);
        }
    }
}
