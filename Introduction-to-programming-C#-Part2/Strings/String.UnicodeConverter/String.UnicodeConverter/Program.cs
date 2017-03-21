using System;
using System.Text;

namespace String.UnicodeConverter
{
    public class UnicodeLiterals
    {

        static string stringToUnicode(string str)
        {

            StringBuilder sb = new StringBuilder();

            char[] values = str.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                string hexOutput = string.Format("\\u{0:X4}", value);

                sb.Append(hexOutput);
            }

            return sb.ToString();
        }

        public static void Main()
        {
            Console.WriteLine("Enter a string to covnert it to unicode literals!\n");
            Console.Write("String: ");
            string input = Console.ReadLine();

            string output = stringToUnicode(input);

            if (output.Length > 0)
            {
                Console.WriteLine("Output: {0}", output);
            }
            else
            {
                Console.WriteLine("Err!");
            }
        }
    }
}
