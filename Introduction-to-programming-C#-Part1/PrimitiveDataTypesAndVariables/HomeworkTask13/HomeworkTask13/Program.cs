using System;

namespace HomeworkTask13 {
    class AppStart {
        
        static void Main() {

            int? nullInt = null;
            double? nullDouble = null;

            Console.WriteLine("Here both nullInt and nullDouble are with value null,\nprinted right after the dots: {0} {1}",
                nullInt, nullDouble);

            Console.WriteLine("Now I add value to nullInt/nullDobule (it's the same).");
            Console.WriteLine("nullInt + 20 = {0}", nullInt+20);

            nullInt = 2;
            nullDouble = 3.4;

            Console.WriteLine("Now I assign value 2 to nullInt and value 3.4 to nullDouble");
            Console.WriteLine("nullInt=2; nullInt: {0}", nullInt.GetValueOrDefault());
        }
    }
}
