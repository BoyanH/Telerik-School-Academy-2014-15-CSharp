using System;

namespace HomeworkTask8 {
    class AppStart {

        static double FindAreaOfTrapezoid(double sideA, double sideB, double height) {


            return (sideA+sideB)/2*height;
        }

        static void Main() {

            double sideA;
            double sideB;
            double height;

            Console.WriteLine("Enter two sides and height of a trapezoid to find its area! :)\n");

            Console.Write("Side A: ");
            bool sideAParsed = double.TryParse(Console.ReadLine(), out sideA);
            Console.Write("Side B: ");
            bool sideBParsed = double.TryParse(Console.ReadLine(), out sideB);
            Console.Write("Height: ");
            bool heightParsed = double.TryParse(Console.ReadLine(), out height);

            if (sideAParsed && sideBParsed && heightParsed) {

                Console.WriteLine("The area of the trapezoid is: {0}", FindAreaOfTrapezoid(sideA, sideB, height));
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }

        }
    }
}
