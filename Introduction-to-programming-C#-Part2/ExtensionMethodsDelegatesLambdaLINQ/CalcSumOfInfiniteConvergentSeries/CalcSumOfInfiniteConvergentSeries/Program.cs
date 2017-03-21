using System;

namespace CalcSumOfInfiniteConvergentSeries
{
    public class CalculateSum
    {

        public static double ConvergentSum(Func<int, double> termValue, double precision)
        {
            int index = 1;
            double sum = 0;
           
            while (termValue(index) > precision)
            {
                sum += termValue(index);
                ++index;
            }
            
            return sum;
        }

        public static void Main()
        {
            Console.WriteLine(ConvergentSum(index => 1 / Math.Pow(2, index - 1), 0.01));
        }
    }
}
