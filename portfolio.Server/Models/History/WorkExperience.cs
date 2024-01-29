namespace portfolio.Server.Models.History
{
    [BsonIgnoreExtraElements]
    public class WorkExperience
    {
        public WorkExperience() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("WorkTitle")]
        public string WorkTitle { get; set; }

        [BsonElement("WorkSubTitle")]
        public string WorkSubTitle { get; set; }

        [BsonElement("WorkStartDate")]
        public DateTime WorkStartDate { get; set; }

        [BsonElement("WorkEndDate")]
        public DateTime WorkEndDate { get; set; }

        [BsonElement("WorkDetail")]
        public string WorkDetail { get; set; }

        [BsonElement("WorkStatus")]
        public byte WorkStatus { get; set; }

        [BsonElement("ContentFileID")]
        public string ContentFileID { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
