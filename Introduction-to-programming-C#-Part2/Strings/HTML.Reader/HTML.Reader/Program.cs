using System;
using System.Collections.Generic;

namespace HTML.Reader
{
    public class ReadHTML
    {

        static string getTitle(string html)
        {

            int indexOfTitleOpen = html.IndexOf("<title>");
            int indexOfTitleClosed = html.IndexOf("</title>");

            if (indexOfTitleOpen == -1 || indexOfTitleClosed == -1)
            {
                return "";
            }

            return html.Substring(indexOfTitleOpen + 7, indexOfTitleClosed - indexOfTitleOpen - 7);
        }

        static string getBodyContent(string html)
        {
            int bodyStartIndex = html.IndexOf("<body>");
            html = html.Substring(bodyStartIndex);

            int cutPartFrom = -1;
            int cutPartLength = 0;
            List<string> removables = new List<string>();

            for (int chr = 0; chr < html.Length; chr++)
            {
                if (html[chr] == '<')
                {
                    cutPartFrom = chr;
                }
                else if (html[chr] == '>' && cutPartFrom != -1)
                {
                    removables.Add( html.Substring(cutPartFrom, cutPartLength + 2) );
                    cutPartFrom = -1;
                    cutPartLength = 0;
                }
                else if (cutPartFrom != -1)
                {
                    ++cutPartLength;
                }
            }

            foreach (string removable in removables)
            {
                html = html.Replace(removable, "");
            }

            return html;
        }

        public static void Main()
        {
            Console.WriteLine("Enter some HTML to get its title and text without them nasty tags!\n");
            Console.Write("HTML: ");
            string inputHTML = Console.ReadLine();
            string htmlTitle = getTitle(inputHTML);
            string bodyContent = getBodyContent(inputHTML);
            Console.WriteLine("Title: {0}", htmlTitle);
            Console.WriteLine("Body Content: \n{0}", bodyContent);
        }
    }
}
