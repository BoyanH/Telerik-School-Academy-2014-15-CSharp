using System;
using System.Collections.Generic;

namespace Text.Styler
{
    public class ApplyTags
    {

        static string upperOpen = "<upcase>";
        static string upperClose = "</upcase>";

        public static string ApllyUpper(string input)
        {

            int n = 0;
            List<string> toChange = new List<string>();
            string reworkedInput = input;

            while((n = input.IndexOf(upperOpen, n) + 1) != 0) {
            
                int crntStartIndex = n - 1 + upperOpen.Length;
                int crntEndIndex = input.IndexOf(upperClose, n);
                string crntReplacement = input.Substring(crntStartIndex, crntEndIndex - crntStartIndex);

                toChange.Add(crntReplacement);
            }

            for (int rep = 0; rep < toChange.Count; rep++)
            {
                reworkedInput = reworkedInput.Replace(toChange[rep], toChange[rep].ToUpper());
            }

            reworkedInput = reworkedInput.Replace(upperOpen, "").Replace(upperClose, "");

            return reworkedInput;
        }

        public static void Main()
        {
            Console.WriteLine("Enter a text wit <upcase></upcase> tags to apply uppercase to it!");
            Console.Write("Text: ");

            string userInput = Console.ReadLine();
            string reworkedInput = ApllyUpper(userInput);

            Console.WriteLine("{0}", new string('-', 70));
            Console.WriteLine(reworkedInput);
        }
    }
}
