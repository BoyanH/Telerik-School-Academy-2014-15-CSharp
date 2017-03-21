using System;

namespace HomeworkTask9 {
    class AppStart {

        static uint Fibonacci(uint nthFibonacci) {

            uint a = 0;
            uint b = 1;
            uint c = 1;

            for (uint i = 3; i <= nthFibonacci; i++) {
                c = b + a;
                a = b;
                b = c;
            }

            if (nthFibonacci == 1) {

                return 0;
            }

            return c;
        }
        
        static void Main() {

            Console.WriteLine("Now I will print the first 100 members of the Fibonacci sequence! :) \n");

            for (uint i = 1; i <= 100; i++) {

                Console.WriteLine("{0}. {1}", i, Fibonacci(i));
            }
        }
    }
}
