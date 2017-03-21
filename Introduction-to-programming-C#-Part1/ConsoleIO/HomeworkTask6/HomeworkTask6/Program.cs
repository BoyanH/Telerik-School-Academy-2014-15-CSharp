using System;
using System.Collections.Generic;

namespace HomeworkTask6 {
    class AppStart {

        static List<double> SolveQE(double a, double b, double c) {

            List<double> result = new List<double>();
            double discriminant = Math.Pow(b, 2) - (4 * a * c);

            if (discriminant > 0) {

                result.Add((-b + Math.Sqrt(discriminant))/2);
                result.Add((-b - Math.Sqrt(discriminant)) / 2);
            }
            else if (discriminant == 0) {

                result.Add((-b) / 2);
            }

            return result;
        }
        
        static void Main() {

            double a, b, c;

            Console.WriteLine("Enter coefficients a, b and c to find the roots of a quadratic equation! :)");

            Console.Write("a: ");
            bool aParsed = double.TryParse(Console.ReadLine(), out a);
            Console.Write("b: ");
            bool bParsed = double.TryParse(Console.ReadLine(), out b);
            Console.Write("c: ");
            bool cParsed = double.TryParse(Console.ReadLine(), out c);

            if (aParsed && bParsed && cParsed) {

                Console.WriteLine("The quadratic equation has {0} roots. They are: {1}",
                                    SolveQE(a, b, c).Count , String.Join("; ", SolveQE(a, b, c)));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
