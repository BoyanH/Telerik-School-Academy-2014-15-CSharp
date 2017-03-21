using System;

namespace HomeworkTask3 {
    class AppStart {

        static void Main() {

            double rectangleWidth;
            double rectangleHeight;

            Console.WriteLine("Enter rectangle's width and height to find its area! :) \n");
            Console.Write("Rectangle's width: ");

            if (double.TryParse(Console.ReadLine(), out rectangleWidth)) {

                Console.Write("Rectangle's height: ");

                if (double.TryParse(Console.ReadLine(), out rectangleHeight)) {

                    Console.WriteLine("The rectangle's area is: {0}", rectangleWidth * rectangleHeight);
                }
                else {

                    Console.WriteLine("Invalid Integer!");
                }
            }
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
