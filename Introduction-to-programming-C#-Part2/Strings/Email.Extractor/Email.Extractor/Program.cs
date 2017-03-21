using System;
using System.Collections.Generic;

namespace Email.Extractor
{
    public class FindEmailsInText
    {

        static List<string> findMails(string text)
        {

            string[] wordArray = text.Split(new char[] { ' ', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> emailsList = new List<string>();

            for (int word = 0; word < wordArray.Length; word++)
            {

                int indexOfAt = wordArray[word].IndexOf("@");

                //code optimization, not check anything else if @ doesnt exist
                if (indexOfAt != -1)
                {

                    int indexOfLastDot = wordArray[word].LastIndexOf(".");

                    //if @ exists, z@xxx.yy => if xxx has minLength of 3, yy has minLength of 2, z has minLength of 1
                    if (indexOfAt > 0 && indexOfLastDot > indexOfAt + 3 && indexOfLastDot < wordArray[word].Length - 2)
                    {
                        emailsList.Add(wordArray[word]);
                    }
                }
            }

            return emailsList;
        }

        public static void Main()
        {

            Console.WriteLine("Enter a text to extract all emails from it!\n(Emails should have identifier >= 1, host >= 3, domain >= 2)\n");
            Console.Write("Text: ");
            string inputText = Console.ReadLine();
            List<string> emailsInText = findMails(inputText);

            Console.WriteLine("Emails Found: \n{0}\n", new string('-', 70));
            for (int email = 0; email < emailsInText.Count; email++)
            {
                Console.WriteLine("{0}{1}", new string(' ', 4), emailsInText[email]);
            }
            Console.WriteLine();
        }
    }
}
