using System;
using System.Text;

namespace Substring.Extension
{
    public class SBSubstringTest
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            sb.Append("01234567");

            Console.WriteLine(sb.Substring(2, 3).ToString()); //from 2 get 3 chars = 234
            Console.WriteLine(sb.Substring(4).ToString()); //from 4 get all(unspecified length) = 4567
        }
    }
}
