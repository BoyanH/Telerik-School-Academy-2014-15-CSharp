using System;

namespace CohesionAndCoupling
{
    public abstract class File
    {
        public static string GetExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new FormatException("The file's name contains no extension, no dot found!");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new FormatException("The file's name contains no extension, no dot found!");
            }

            string untilExtension = fileName.Substring(0, indexOfLastDot);
            return untilExtension;
        }
    }
}
