namespace portfolio.Server.Models.About
{
    [BsonIgnoreExtraElements]
    public class Socials
    {
        public Socials() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("link")]
        public string link { get; set; }

        [BsonElement("icon")]
        public string icon { get; set; }

        [BsonElement("label")]
        public string label { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }


    }
}
