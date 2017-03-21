using System;
using System.Text;

namespace String.Encrypter
{
    public class EncryptDecrypt
    {

        public static string EncryptString(string str, string key)
        {
            StringBuilder encrypted = new StringBuilder();

            for (int chr = 0; chr < str.Length; chr++)
            {

                encrypted.Append((char)(str[chr] ^ key[chr % key.Length]));
            }

            return encrypted.ToString();
        }

        public static string DecryptString(string str, string key)
        {
            return EncryptString(str, key);
        }

        public static void Main()
        {
            Console.WriteLine("Input a string and a key to encrypt/decrypt the string with the key!");

            Console.Write("String: ");
            string userInput = Console.ReadLine();
            Console.Write("Key: ");
            string key = Console.ReadLine();

            string encrypted = EncryptString(userInput, key);

            Console.WriteLine("Encrypted \"{0}\" with \"{1}\": {2}", userInput, key, encrypted);
            Console.WriteLine("Decrypted \"{0}\" with \"{1}\": {2}", userInput, key, DecryptString(encrypted, key));
        }
    }
}
