using System;

namespace HomeworkTask1 {
    
    class ApplicationStart {
    
        static void Main() {

            ushort theUShortOne = 52130;
            sbyte theSbyteOne = -115;
            byte theByteOne = 97;
            short theShortOne = -10000;
            int theIntOne = 4825932;

            Console.WriteLine("My numbers are: \n ushort: {0}, \n sbyte: {1}, \n byte: {2}, \n short: {3}, \n int: {4}", 
                theUShortOne, theSbyteOne, theByteOne, theShortOne, theIntOne);
        }
    }
}
