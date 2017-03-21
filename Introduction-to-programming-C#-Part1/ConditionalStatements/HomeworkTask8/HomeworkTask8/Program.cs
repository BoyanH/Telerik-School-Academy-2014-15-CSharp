using System;

namespace HomeworkTask8 {
    class AppStart {
        
        static void Main() {

            int num;
            double doubleNum;
            string aString, type;

            Console.WriteLine("Enter an int/double/string. If its an int/double, it will be increased with 1." +
                " Else, an '*' character will be added to the end of it! :)\n");

            Console.Write("Variable: ");
            var variable = Console.ReadLine();

            bool isInt = int.TryParse(variable, out num);
            bool isDouble = double.TryParse(variable, out doubleNum) && !isInt;
            bool isString = !isInt && !isDouble;

            if (isInt) {

                type = "int";
            }
            else if (isDouble) {

                type = "double";
            }
            else if (isString) {

                type = "string";
            }
            else {

                type = "dafuq";
            }

            switch (type) {

                case "int": 
                    ++num;
                    Console.WriteLine("Input: {0}, Type: {1}, Output: {2}",
                        variable, type, num);
                    break;
                case "double":
                    ++doubleNum;
                    Console.WriteLine("Input: {0}, Type: {1}, Output: {2}",
                        variable, type, doubleNum);
                    break;
                case "string":
                    aString = variable + "*";
                    Console.WriteLine("Input: {0}, Type: {1}, Output: {2}",
                        variable, type, aString);
                    break;
                default:
                    Console.WriteLine("There is no such animal!!! xD");
                    break;
            }

        }
    }
}
