using System;

namespace Syntax.Checker
{
    public class BracketsPutCorrectly
    {

        public static bool BracketsProperlyPlaced(string input)
        {

            char[] inputCharArr = input.ToCharArray();
            int openedBrackets = 0;

            for (int character = 0; character < inputCharArr.Length; character++)
            {
                
                if(inputCharArr[character] == '(') 
                {
                
                    ++openedBrackets;
                }
                else if (inputCharArr[character] == ')')
                {

                    if(openedBrackets > 0) 
                    {
                    
                        --openedBrackets;
                    }
                    else 
                    {
                    
                        return false;
                    }
                }
            }

            if (openedBrackets == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter peace of code to check if all brackets are placed correctly!\n");
            Console.Write("Input code: ");
            string userInput = Console.ReadLine();

            if (BracketsProperlyPlaced(userInput))
            {
                Console.WriteLine("Congratulations! All seems fine! ;)");
            }
            else
            {
                Console.WriteLine("Incorrect placement of brackets!");
            }
        }
    }
}
