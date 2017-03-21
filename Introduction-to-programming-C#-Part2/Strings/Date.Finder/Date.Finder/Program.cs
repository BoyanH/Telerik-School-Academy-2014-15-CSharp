using System;
using System.Collections.Generic;
using System.Globalization;

namespace Date.Finder
{
    public class FindDates
    {
        static List<DateTime> findDates(string text)
        {

            string[] wordArray = text.Split(new char[] { ' ', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<DateTime> dateList = new List<DateTime>();

            for (int word = 0; word < wordArray.Length; word++)
            {

                int indexOfDot = wordArray[word].IndexOf(".");
                int lastIndexOfDot = wordArray[word].LastIndexOf(".");

                //if 2+ dots in word
                if (indexOfDot != lastIndexOfDot)
                {

                    bool failed = false;
                    DateTime crntDate = new DateTime();

                    try
                    {
                        crntDate = DateTime.ParseExact(wordArray[word], "dd.MM.yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    }
                    catch
                    {
                        failed = true;
                    }

                    if (!failed)
                    {
                        dateList.Add(crntDate);
                    }
                }
            }

            return dateList;
        }

        public static void Main()
        {
            // Set culture to en-CA.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-CA");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("en-CA");

            Console.WriteLine("Enter a text to find all dates in format dd.MM.yyyy and print them like a true Canadian!");
            Console.Write("Text: ");
            string inputText = Console.ReadLine();
            List<DateTime> datesInText = findDates(inputText);

            Console.WriteLine("Dates Found: \n{0}\n", new string('-', 70));
            for (int date = 0; date < datesInText.Count; date++)
            {
                Console.WriteLine("{0}{1}", new string(' ', 4), datesInText[date]);
            }
            Console.WriteLine();
        }
    }
}
