using System;
using System.IO;

namespace Path.Reader
{
    public class ReadPath
    {

        public static string ReadFromConsolePath(string path)
        {
            return File.ReadAllText(path);
        }

        public static void Main()
        {
            Console.WriteLine("Enter the absolute path of a file to see its text on the console!\n");
            Console.Write("Path: ");
            string inputPath = Console.ReadLine();

            try
            {
                string fileText = ReadFromConsolePath(inputPath);
                Console.WriteLine("The file contains: \n{0}\n", new string('-', 70));
                Console.WriteLine(fileText);
                Console.WriteLine("\n{0}", new string('-', 70));
            }
            catch (FormatException)
            {
                Console.WriteLine("Path is not in the right format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //doesn't really get any more user-friendly than that, I suppose ;)
            }
        }
    }
}
