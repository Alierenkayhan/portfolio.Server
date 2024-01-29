namespace portfolio.Server.Models.About
{
    [BsonIgnoreExtraElements]
    public class Skills
    {
        public Skills() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("proficientWith")]
        public string proficientWith { get; set; }

        [BsonElement("exposedTo")]
        public string exposedTo { get; set; }


        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }


    }
}
