using System;
using System.Text;

namespace Substring.Extension
{
    public static class Extensions
    {

        public static StringBuilder Substring(this StringBuilder sb, int index, int length = -1) 
        {
            string input = sb.ToString();
            var outputSb = new StringBuilder();

            if (length == -1)
            {
                length = input.Length - index;
            }

            outputSb.Append(input.Substring(index, length));

            return outputSb;   
        }
    }
}
