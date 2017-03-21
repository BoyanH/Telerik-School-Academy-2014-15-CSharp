using System;

namespace String.Simplifier
{
    class RemoveAccessChars
    {

        static string removeRepetitions(string str)
        {

            string reworkedStr = str;
            int chr = 0;

            while (chr < reworkedStr.Length - 1) //as we are removing next elem on repetition we never need to check te last elem, as there is no next then
            {
                while (reworkedStr[chr] == reworkedStr[chr + 1]) //if crnt elem == next elem
                {
                    reworkedStr = reworkedStr.Remove(chr + 1, 1); //remove next element
                }

                ++chr; //got check next with nextNext
            }

            return reworkedStr;
        }

        public static void Main()
        {
            Console.WriteLine("Input a string to remove repetittions (example: aaasssddd => asd)!\n");
            Console.Write("String: ");
            string str = Console.ReadLine();
            Console.WriteLine("Output: {0}", removeRepetitions(str));
        }
    }
}
