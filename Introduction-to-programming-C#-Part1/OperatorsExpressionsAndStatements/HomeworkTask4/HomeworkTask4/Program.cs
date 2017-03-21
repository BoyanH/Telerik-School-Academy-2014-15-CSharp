using System;

namespace HomeworkTask4 {
    class AppStart {
        
        static void Main() {

            int givenInt;

            Console.WriteLine("Is the third digit from right to left 7? Enter a number to find out! \n");
            Console.Write("Number: ");

            if (int.TryParse(Console.ReadLine(), out givenInt)) {

                Console.WriteLine((givenInt/100)%10 == 7); //When we divide an int by 100, we remove its final 2 digits.
                                                          // Then when we get the rest of dividing it by 10 we actually get
                                                         //  The 3-rd digit from right to left of the starting int
            }                                           //   And check if it's 7
            else {

                Console.WriteLine("Invalid Integer!");
            }
        }
    }
}
