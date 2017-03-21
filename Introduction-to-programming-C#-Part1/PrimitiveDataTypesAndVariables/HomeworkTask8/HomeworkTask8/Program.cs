using System;

namespace HomeworkTask8 {
    
    class AppStart {
    
        static void Main() {
        
            string theSlashEscapingMethod = "The \"use\" of quotations causes difficulties.";
            string uselesslyLongEscapingMethod =  @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine("First method:  {0}", theSlashEscapingMethod);
            Console.WriteLine("Second method: {0}", uselesslyLongEscapingMethod);
        }
    }
}
