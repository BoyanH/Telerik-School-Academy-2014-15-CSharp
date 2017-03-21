using System;
using System.Net;

namespace File.Downloader
{
    public class DownloadFile
    {

        public static void FromConsoleURL(string url, string fileName)
        {
            int lastDotIndx = url.LastIndexOf(".");

            if (lastDotIndx == -1)
            {
                throw new FormatException("Invalid file URL!");
            }

            string crntFormat = url.Substring(lastDotIndx);

            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(url, string.Format("{0}{1}", fileName, crntFormat));
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter url and file name, to download the file from the url and store it as fileName.extension!\n");
            Console.WriteLine("Note that it will be saved in the current directory of the application, a.k.a where it is complied" +
                ", a.k.a. \"bin/Debug/...\"\n");

            Console.Write("URL: ");
            string inputURL = Console.ReadLine();
            Console.Write("Filename (no .extension needed): ");
            string fileName = Console.ReadLine();

            try
            {
                FromConsoleURL(inputURL, fileName);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(new string('!', 80));
                Console.WriteLine("Format Exception: " + ex.Message);
                Console.WriteLine(new string('!', 80));
            }
            catch (Exception ex)
            {
                Console.WriteLine(new string('!', 80));
                Console.WriteLine(ex.Message);
                Console.WriteLine(new string('!', 80));
            }
        }
    }
}
