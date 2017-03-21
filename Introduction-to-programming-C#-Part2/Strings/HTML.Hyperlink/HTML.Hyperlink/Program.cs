using System;

namespace HTML.Hyperlink
{
    public class Replacer
    {

        public static string ReplaceHyperlinksWithUrlTags(string html)
        {
            while(html.IndexOf("<a") != -1) 
            {
                int aStartIndex = html.IndexOf("<a");
                int hrefStartIndex = aStartIndex + 9; //9, because aStartIndex is index of <, and we need inex of " in <a href="
                int aLastIndex = 0; //will always be changed
                char[] fromHrefToEndCharArr = html.Substring(aStartIndex + 9).ToCharArray();

                for (int i = 0; i < fromHrefToEndCharArr.Length; i++)
                {
                    if (fromHrefToEndCharArr[i] == '>')
                    {
                        aLastIndex = hrefStartIndex + i;
                        break;
                    }
                }

                string hrefContent = html.Substring(hrefStartIndex, aLastIndex - hrefStartIndex - 1); //-1 comes from the second "
                string replaceable = html.Substring(aStartIndex, aLastIndex + 1 - aStartIndex); //+1 in order to get the > sign too
                string newContent = string.Format("[URL=\"{0}\"]", hrefContent);

                html = html.Replace(replaceable, newContent).Replace("</a>", "[/URL]");
            }

            return html;
        }

        public static void Main()
        {
            Console.WriteLine("Insert HTML to change all <a href=\"...\"></a> tags with [URL=\"...\"][/URL] ones!\n");
            Console.Write("HTML: ");
            string userInput = Console.ReadLine();
            string output = ReplaceHyperlinksWithUrlTags(userInput);

            Console.WriteLine("{0}\nOutput: \n{0}\n{1}", new string('-', 70), output);
        }
    }
}
