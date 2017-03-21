using System;
using System.Linq;

namespace Numbers.Divideable
{
    public class DivideableBy3And7
    {
        public static void Main()
        {
            var numbers = new[] { 2, 3, 232, 32, 12, 8, 5, 9, 4, 21, 63 };

            var divideableNumbersMethods = numbers
                .Where(num => num % 3 == 0 && num % 7 == 0);

            var divideableNumbersLinq =
                from number in numbers
                where number % 3 == 0 && number % 7 == 0
                select number;

            Console.WriteLine("All numbers: {0}", string.Join(", ", numbers));
            Console.WriteLine("Divideable by 3 and 7 Methods: {0}", string.Join(", ", divideableNumbersMethods));
            Console.WriteLine("Divideable by 3 and 7 Linq: {0}", string.Join(", ", divideableNumbersLinq));
        }
    }
}
