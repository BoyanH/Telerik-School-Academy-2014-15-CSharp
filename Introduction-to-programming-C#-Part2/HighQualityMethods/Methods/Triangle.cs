using System;

namespace Methods
{
    public class Triangle
    {
        public static double CalcArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentNullException("Sides should be positive.");
            }
            else if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("Non-existing triangle!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }
    }
}
