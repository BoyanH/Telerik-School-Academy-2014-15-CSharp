using System;

namespace Good.Bye
{
    public class SquareRootByeBye
    {

        public static void PrintSquareRoot(string s)
        {
            double num = Double.Parse(s);

            if (num < 0)
            {
                throw new ArgumentOutOfRangeException("Square root of a negative number is not defined!");
            }

            Console.WriteLine("Square root from {0} is: {1}", num, Math.Sqrt(num));
        }

        public static void Main()
        {

            Console.WriteLine("Enter a number to find its square root!/n");

            try
            {
                string inputString = Console.ReadLine();
                PrintSquareRoot(inputString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Number is invalid!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
