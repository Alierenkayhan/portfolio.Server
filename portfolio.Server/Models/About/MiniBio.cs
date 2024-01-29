namespace portfolio.Server.Models.About
{
    [BsonIgnoreExtraElements]
    public class MiniBio
    {
        public MiniBio() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("emoji")]
        public string emoji { get; set; }

        [BsonElement("text")]
        public string text { get; set; }


        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }


    }
}
