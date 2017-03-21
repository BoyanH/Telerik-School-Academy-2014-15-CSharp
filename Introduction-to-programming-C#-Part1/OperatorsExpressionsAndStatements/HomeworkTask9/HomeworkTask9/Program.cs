using System;

namespace HomeworkTask9 {
    class AppStart {

        //Optional Arguments (Can pass arguments to check for another Circle, won't explode if not parsed)
        static bool IsInCircle(double pointX, double pointY, double circleCenterX = 1, double circleCenterY = 1, double circleRadius = 3) {

            return (Math.Pow(circleCenterX - pointX, 2) + Math.Pow(circleCenterY - pointY, 2) <= Math.Pow(circleRadius, 2));
        }

        //Optional Arguments (Can pass arguments to check for another Rect, won't explode if not parsed)
        static bool IsOutOfRectangle(double pointX, double pointY, double rectX = -1, double rectY = 1, double rectWidth = 6, double rectHeight = 2) {

            //If point is to the left of the left side or the distance between it and the left side is > width of rect
            bool sideBoundariesPassed = pointX < rectX || pointX - rectX > rectWidth;
            //If point is over the top side or the distance between the poinY and the top side is bigger than height
            bool heightBoundariesPassed = pointY > rectY || rectY - pointY > rectHeight;
         

            return sideBoundariesPassed||heightBoundariesPassed;
        }

        static void Main() {

            double pointX;
            double pointY;

            Console.WriteLine("Write a Points coordinats to see if it is within the circle K((1,1), 3) " +
                                "and out of the rectangle R(Top: 1, Left: -1, Width: 6, Height: 2) \n");

            Console.Write("Point coordinate X: ");
            bool isPointXParsed = double.TryParse(Console.ReadLine(), out pointX);
            Console.Write("Point coordinate Y: ");
            bool isPointYParsed = double.TryParse(Console.ReadLine(), out pointY);

            if (isPointXParsed && isPointYParsed) {

                if (IsInCircle(pointX, pointY) && IsOutOfRectangle(pointX, pointY)) {

                    Console.WriteLine("The point is both in circle K and out of rect R! :)");
                }
                else if (IsInCircle(pointX, pointY)) {

                    Console.WriteLine("The point is in circle K, but also in rect R! :/");
                }
                else if (IsOutOfRectangle(pointX, pointY)) {

                    Console.WriteLine("The point is out of rect R, but also out of circle K! :/");
                }
                else {

                    Console.WriteLine("DISASTER! The point is out of circle R, and in rect K");
                }
            }
        }
    }
}
