using System;

namespace HomeworkTask7 {
    
    class Program {
        static void Main() {
        
            string hello = "Hello";
            string world = "World";
            object helloWorld = hello + " " + world + "!";

            string finalSentance = helloWorld.ToString();

            Console.WriteLine(finalSentance);
        }
    }
}
