using System;

namespace HomeworkTask10 {
    class AppStart {

        static void Main() {

            double sum = 1;
            double repetition = 1;
            double tempInt = 0;

            do {

                ++repetition;
                tempInt = sum;
                sum += (((repetition % 2) == 0) ? +1.0 : -1.0) /repetition;

            } while (Math.Abs(sum - tempInt) >= 0.001);

            Console.WriteLine("The sum of the sequence 1 + 1/2 - 1/3 + 1/4 - 1/5... is {0}", Math.Round(sum, 3));
        }
    }
}
