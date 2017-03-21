using System;

namespace Methods
{
    public class Number
    {
        public static string ToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Digit must be between 0 and 9!");
            }
        }

        public static void PrintWithFixedPoint(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercentage(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintPadded(double number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
