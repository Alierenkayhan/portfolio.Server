namespace portfolio.Server.Models.About
{
    [BsonIgnoreExtraElements]
    public class Hobbies
    {
        public Hobbies() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("label")]
        public string label { get; set; }

        [BsonElement("emoji")]
        public string emoji { get; set; }


        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }


    }
}
