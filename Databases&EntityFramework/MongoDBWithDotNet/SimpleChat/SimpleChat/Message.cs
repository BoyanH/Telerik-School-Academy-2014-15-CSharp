namespace SimpleChat
{

    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Content { get; set; }

        public User FromUser { get; set; }

        public DateTime SentTime { get; set; }
    }
}
