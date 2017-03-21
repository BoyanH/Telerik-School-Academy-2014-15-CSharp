using System;

namespace HomeworkTask11 {
    class AppStart {
        static void Main() {

            int five = 5;
            int ten = 10;

            five = five + ten; //Both variables are now saved IN the first one
            ten = five - ten; //Now the second, which was added to first is now taken from it and the sum (first int) is assigned
                              //to second int. (Here "Ten" is already "five")
            five = five - ten;//"Five" is still the sum of both, so       both values - the now first one = the now second one

            Console.WriteLine("Integer with first value of five: {0}; \nInteger with first value of ten: {1}", five, ten);
        }
    }
}
