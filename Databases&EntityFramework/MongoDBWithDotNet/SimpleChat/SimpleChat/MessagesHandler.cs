namespace SimpleChat
{

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System.Text;

    public class MessagesHandler
    {
        private const string DatabaseHost = "mongodb://BoyanH:magicunicornsbiatch@ds031711.mongolab.com:31711/simplechat";
        private const string DatabaseName = "simplechat";

        private static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public static IEnumerable<Message> GetMessages()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);
            var messagesCollection = db.GetCollection<Message>("Messages");

            return messagesCollection.FindAll();
        }

        public static void SendMessage(string content)
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);
            var messagesCollection = db.GetCollection<Message>("Messages");

            var newMessage = new Message()
            {
                Content = content,
                FromUser = Identity.CrntUser,
                SentTime = DateTime.Now
            };

            messagesCollection.Insert(newMessage);
        }
    }
}
