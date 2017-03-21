using System;

namespace URLParser
{
    class ExtractData
    {

        public static string[] getElements(string url)
        {

            string[] urlResources = new string[3];
            int dotsIndex = url.IndexOf(':'); // also length of protocol

            urlResources[0] = url.Substring(0, dotsIndex); //protocol

            //leave only the part we still need, a.k.a server + resource
            url = url.Replace(url.Substring(0, dotsIndex + 3), "");
            int serverLength = url.IndexOf('/'); //first dash is now end of server

            urlResources[1] = url.Substring(0, serverLength); //server
            urlResources[2] = url.Replace(urlResources[1], ""); //resource (evertything else)

            return urlResources;
        }

        public static void Main()
        {

            Console.WriteLine("Enter an URL to get its protocol, server and resource!\n");

            Console.Write("URL: ");
            string inputURL = Console.ReadLine();
            string[] urlResources = getElements(inputURL);

            Console.WriteLine("Resources: \n{0}\n", new string('-', 70));
            for (int item = 0; item < urlResources.Length; item++)
            {

                string dataType;

                switch (item)
                {
                    case 0:
                        dataType = "Protocol";
                        break;
                    case 1:
                        dataType = "Server";
                        break;
                    case 2:
                        dataType = "Resource";
                        break;
                    default:
                        dataType = "";
                        break;
                }

                Console.WriteLine("{0} : {1}", dataType, urlResources[item]);
            }

        }
    }
}
