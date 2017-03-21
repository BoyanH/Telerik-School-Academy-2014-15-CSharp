using System;

namespace HomeworkTask3 {
    
    class ApplicationStart {

        static void CompareFloats(float floatOne, float floatTwo) {

            Console.WriteLine("Comparing float {0} and float {1} !", floatOne, floatTwo);
            bool isOneGreaterThanTwo = floatOne == floatTwo; //Here I am comparing using ==, which will not work great
                                                            // for floats, but is much faster. When false, I double check
                                                           //  with the module of floatOne and floatTwo

            if (!isOneGreaterThanTwo) {

                isOneGreaterThanTwo = Math.Abs(floatOne - floatTwo) < 1e-6; //1e-6 is 1*10^-6 (A.K.A. 0.000001)
                Console.WriteLine("First check is returning false, using Math.Abs()");
            }
            
            Console.WriteLine("compareFloats({0}, {1}) returns {2}", floatOne, floatTwo, isOneGreaterThanTwo);
        }
    
        static void Main() {

            float firstFloat = 5.3f;
            float secondFloat = 6.01f;
            float thirdFloat = 5.00000001f;
            float fourthFloat = 5.00000003f;

            CompareFloats(firstFloat, secondFloat);
            CompareFloats(thirdFloat, fourthFloat);



        }
    }
}
