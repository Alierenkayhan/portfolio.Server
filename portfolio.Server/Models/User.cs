namespace portfolio.Server.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public User() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

    }
}
