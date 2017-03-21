using System;
using System.Collections.Generic;

namespace Text.Word
{
    public class Occurances
    {

        static Dictionary<string, int> findOccurances(string str)
        {
            char[] charArr = str.ToCharArray();
            var dic = new Dictionary<string, int>();

            for (int ch = 0; ch < charArr.Length; ch++)
            {
                dic[charArr[ch].ToString()] = dic.ContainsKey(charArr[ch].ToString()) ? dic[charArr[ch].ToString()] + 1 : 1;
            }

            return dic;
        }

        public static void Main()
        {
            string text = Console.ReadLine();
            var dict = findOccurances(text);

            foreach (var item in dict)
            {
                Console.WriteLine("{0}{1}: {2}", new string(' ', 4),item.Key, item.Value);
            }
        }
    }
}
