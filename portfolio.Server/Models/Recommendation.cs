namespace portfolio.Server.Models
{
    [BsonIgnoreExtraElements]
    public class Recommendation
    {
        public Recommendation() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("PersonNameSurname")]
        public string PersonNameSurname { get; set; }

        [BsonElement("PersonTitle")]
        public string PersonTitle { get; set; }

        [BsonElement("Connection")]
        public string Connection { get; set; }

        [BsonElement("Website")]
        public string Website { get; set; }

        [BsonElement("RecommendationDetail")]
        public string RecommendationDetail { get; set; }

        [BsonElement("ContentFileID")]
        public string ContentFileID { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
