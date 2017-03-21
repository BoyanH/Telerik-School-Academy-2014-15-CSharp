using System;

namespace HomeworkTask4 {
    
    class AppStart {
        
        static void Main() {

            int intAsHexadecimal;

            unchecked {
                intAsHexadecimal = (int)0xFE;
            }

            Console.WriteLine("Here is my integer variable with value 254 in hexadecimal format: {0}", intAsHexadecimal);
        }
    }
}
