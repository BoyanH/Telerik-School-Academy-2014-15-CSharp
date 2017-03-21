using System;

namespace Number.Reader
{
    public class ReadFromConsole
    {

        public static int ReadIntFromConsole(int start, int end)
        {
            int num;
            bool intParsed = int.TryParse(Console.ReadLine(), out num);

            if (!intParsed)
            {
                throw new FormatException("Integer could not be read from console, wrong format!");
            }

            if (num < start || num > end)
            {
                throw new ArgumentOutOfRangeException(string.Format("Num must be between {0} and {1}!", start, end));
            }

            return num;
        }

        public static void Main()
        {
            Console.WriteLine("Enter 10 ints in ascending order, which are all >0 and <100!");
            int[] numsFromConsole = new int[10];

            try
            {
                for (int crntNum = 0; crntNum < numsFromConsole.Length; crntNum++)
                {
                    int crntStart;

                    if (crntNum == 0)
                    {
                        crntStart = 0;
                    }
                    else
                    {
                        crntStart = numsFromConsole[crntNum - 1];
                    }
                    numsFromConsole[crntNum] = ReadIntFromConsole(crntStart, 100 - numsFromConsole.Length + 1 + crntNum);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
