using System;
using System.Collections;

namespace IE.Math
{
    public class TestIEMath
    {
        public static void Main()
        {
            var arr = new double[] { 1, 3, -15, 8, 2.2, 3.8, -7, 0.001 };

            Console.WriteLine("SUM: {0}", arr.Sum());
            Console.WriteLine("PRODUCT: {0}", arr.Product());
            Console.WriteLine("MIN: {0}", arr.Min());
            Console.WriteLine("MAX: {0}", arr.Max());
            Console.WriteLine("AVERAGE: {0}", arr.Average());
        }
    }
}
