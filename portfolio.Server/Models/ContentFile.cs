namespace portfolio.Server.Models
{
    [BsonIgnoreExtraElements]
    public class ContentFile
    {
        public ContentFile() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("FileTitle")]
        public string FileTitle { get; set; }

        [BsonElement("FileType")]
        public byte FileType { get; set; }
       
        [BsonElement("FileStatus")]
        public byte FileStatus { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
