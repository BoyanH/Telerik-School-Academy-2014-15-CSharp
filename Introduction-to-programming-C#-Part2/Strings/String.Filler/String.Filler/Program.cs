using System;

namespace String.Filler
{
    public class UpToTwenty
    {
        public static void Main()
        {

            Console.WriteLine("Enter a string of max 20 chars to get a string with length of 20 chars!");
            string inputString = Console.ReadLine();

            if (inputString.Length > 20)
            {
                Console.WriteLine("Must contain less than 20 chars!");
            }
            else
            {
                if (inputString.Length < 20)
                {
                    inputString = string.Concat(inputString, new string('*', 20 - inputString.Length));
                }

                Console.WriteLine("Output: {0}", inputString);
            }

        }
    }
}
