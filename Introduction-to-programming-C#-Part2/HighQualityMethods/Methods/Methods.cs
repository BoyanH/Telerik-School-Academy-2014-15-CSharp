using System;

namespace Methods
{
    class Methods
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(Triangle.CalcArea(3, 2, 5));
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine("Cannot calculate area of triangle! {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine("Cannot calculate area of triangle! {0}", ex.Message);
            }


            try
            {
                Console.Error.WriteLine(Number.ToDigit(5));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }


            try
            {
                Console.WriteLine(new int[] {5, -1, 3, 2, 14, 2, 3}.FindMax());
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }


            Number.PrintWithFixedPoint(1.3);
            Number.PrintAsPercentage(0.75);
            Number.PrintPadded(2.30);

            
            Line newLine = new Line(3, -1, 3, 2.5);
            Console.WriteLine(Line.CalcLength(newLine)); //can be called both using an instance of Line or by passing 4 points
            Console.WriteLine("Horizontal?: " + Line.IsHorizontal(newLine));
            Console.WriteLine("Vertical?: " + Line.IsVertical(newLine));

            try //Will throw exception if some properties are not valid
            {
                Student peter = new Student("Petar", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
                Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Vidin");

                Console.WriteLine("{0} older than {1} -> {2}",
                    peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
