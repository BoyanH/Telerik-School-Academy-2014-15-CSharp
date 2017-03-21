using System;
using System.IO;

namespace Point.Manager
{
    class PathStorage
    {
        public static void WriteToExternalPath(Path path, string outputFile)
        {
            using (StreamWriter w = File.AppendText(outputFile))
            {
                w.Write(";{0}", path.ToString());
            }
        }

        public static Path ReadExternalPath(string inputFile)
        {
            string stringifiedPath =  File.ReadAllText(inputFile);

            return Path.ParsePath(stringifiedPath);
        }
    }
}
