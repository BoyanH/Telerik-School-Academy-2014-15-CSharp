using System;

namespace String.Reverser
{
    public class ReverseString
    {

        public static string GiveReversed(string givenString)
        {
            char[] charArr = givenString.ToCharArray();
            Array.Reverse(charArr);
            
            return new string(charArr);
        }

        public static void Main()
        {

            Console.WriteLine("Enter a string to reverse it!\n");
            Console.Write("Input string: ");

            string inputString = Console.ReadLine();
            string reversedString = GiveReversed(inputString);

            Console.WriteLine("Reversed string: {0}", reversedString);
        }
    }
}
