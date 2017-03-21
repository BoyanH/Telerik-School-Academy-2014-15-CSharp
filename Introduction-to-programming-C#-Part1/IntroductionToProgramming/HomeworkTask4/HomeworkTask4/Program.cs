using System;

namespace HomeworkTask4 {
    
    class Program {
    
        static void Main() {

            int value = 1234;
            int power = 2;

                Console.WriteLine("{0}^{1} = {2}", value, power, (long)Math.Pow(value, power));
        }
    }
}
