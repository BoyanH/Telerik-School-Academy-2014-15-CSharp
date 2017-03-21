using System;

namespace HomeworkTask2 {
    class AppStart {
        
        static void Main() {

            double circleRadius;

            Console.WriteLine("Enter the raidus of a circle to find its perimeter and area! ;)");
            Console.Write("Radius: ");

            if (double.TryParse(Console.ReadLine(), out circleRadius)) {

                Console.WriteLine("Perimeter: {0}; \nArea: {1}", 2*Math.PI*circleRadius, Math.PI*Math.Pow(circleRadius, 2));
            }
        }
    }
}
