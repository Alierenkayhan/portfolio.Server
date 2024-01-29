namespace portfolio.Server.Models.About
{
    [BsonIgnoreExtraElements]
    public class About
    {
        public About() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("firstName")]
        public string firstName { get; set; }

        [BsonElement("lastName")]
        public string lastName { get; set; }

        [BsonElement("position")]
        public string position { get; set; }

        [BsonElement("bio")]
        public string bio { get; set; }

        [BsonElement("selfPortrait")]
        public string selfPortrait { get; set; }


        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }


    }
}
