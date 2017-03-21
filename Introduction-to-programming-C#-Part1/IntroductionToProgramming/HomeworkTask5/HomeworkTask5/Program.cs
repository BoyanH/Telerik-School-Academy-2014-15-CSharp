using System;

namespace HomeworkTask5 {
    
    class Program {
    
        static void Main(string[] args) {

            int multiplyer;

            for (int i = 2; i < 12; i++) {

                if (i % 2 == 0) {
                    multiplyer = 1;
                }
                    else {
                        multiplyer = -1;
                    }

                Console.WriteLine(i*multiplyer);

            }
        }
    }
}
