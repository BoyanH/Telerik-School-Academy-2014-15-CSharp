namespace SimpleChat
{

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {

        private string userName;

        public User(string username)
        {
            this.UserName = username;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value.Length >= 3)
                {
                    this.userName = value;
                }
            }
        }
    }
}
