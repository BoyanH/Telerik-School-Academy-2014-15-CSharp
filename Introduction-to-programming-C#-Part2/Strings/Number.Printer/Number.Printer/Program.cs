using System;
using System.Globalization;

namespace Number.Printer
{
    public class PrintNumber
    {

        public static void Print(double num)
        {
            int intNum = Convert.ToInt16(num);
            Console.WriteLine("As a Decimal: {0,15}", num);
            Console.WriteLine("As a Hexadecimal: {0,15:X}", intNum);
            Console.WriteLine("As Percentage: {0,15:P}", num);
            Console.WriteLine("In Scientific Notation: {0,15:E}", num);
        }

        public static void Main()
        {
            Console.WriteLine("Enter number to print it in many ways!\n");
            double num;

            Console.Write("Number: ");
            bool numParsed = double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num);

            Print(num);
        }
    }
}
