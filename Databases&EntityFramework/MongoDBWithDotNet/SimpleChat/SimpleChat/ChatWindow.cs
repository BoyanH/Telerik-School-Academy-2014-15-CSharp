namespace SimpleChat
{

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChatWindow
    {

        private static int displayedMessagesCount = 0;

        private static void PrintAllMessages()
        {
            var newMessages = MessagesHandler.GetMessages();

            if (newMessages.Count() == displayedMessagesCount)
            {
                return;
            }

            displayedMessagesCount = newMessages.Count();

            Console.Clear();

            Console.WriteLine("{0}\n{1}Sample Chat\n{0}\n", new string('-', 70), new string(' ', 30));
            foreach (var message in newMessages)
            {
                Console.WriteLine("{0:dd.MM.yy hh:mm:ss}", message.SentTime);
                Console.WriteLine("{0}: {1}\n", message.FromUser.UserName, message.Content);
            }
            Console.WriteLine("{0}\n", new string('-', 70));
        }

        private static void AskForNewMessage()
        {
            Console.Write("{0}: ", Identity.CrntUser.UserName);

            MessagesHandler.SendMessage(Console.ReadLine());
        }

        public static void Main()
        {

            Console.Write("Enter Username: ");

            Identity.CrntUser = new User(Console.ReadLine());

            var messages = MessagesHandler.GetMessages();

            foreach (var message in messages)
            {
                Console.WriteLine(message.Content);
            }

            Task.Run(() =>
            {

                while (true)
                {
                    PrintAllMessages();
                    Thread.Sleep(500);
                }
            });

            while (true)
            {
                Thread.Sleep(500);
                AskForNewMessage();
            }
        }
    }
}
