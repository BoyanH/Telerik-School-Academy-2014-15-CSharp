using System;

namespace HomeworkTask6 {
    class AppStart {
        static void Main() {

            int circleCenterX = 0;
            int circleCenterY = 5;
            double circleRadius;
            double pointX;
            double pointY;

            Console.WriteLine("Enter X and Y coordinats of a point and the radius of" +
                "a circle K(0;5) to find out if the point is in the circle! \n");
            Console.Write("X of the point: ");
            bool isXParsed = double.TryParse(Console.ReadLine(), out pointX);
            Console.Write("Y of the point: ");
            bool isYParsed = double.TryParse(Console.ReadLine(), out pointY);
            Console.Write("Radius of the circle: ");
            bool isRParsed = double.TryParse(Console.ReadLine(), out circleRadius);

            if (isXParsed && isYParsed && isRParsed) {

                if (Math.Pow(circleCenterX - pointX, 2) + Math.Pow(circleCenterY - pointY, 2) <= Math.Pow(circleRadius, 2)) {

                    Console.WriteLine("The point ({0}, {1}) belongs to circle K(0, 5) with radius {2}! :)",
                        pointX, pointY, circleRadius);
                }
                else {

                    Console.WriteLine("The point ({0}, {1}) DOES NOT belong to circle K(0, 5) with radius {2}! :)",
                        pointX, pointY, circleRadius);
                }

            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
