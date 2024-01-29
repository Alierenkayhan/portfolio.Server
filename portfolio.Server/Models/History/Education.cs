namespace portfolio.Server.Models.History
{
    [BsonIgnoreExtraElements]
    public class Education
    {
        public Education() => Id = Guid.NewGuid();
        
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("EducationTitle")]
        public string EducationTitle { get; set; }

        [BsonElement("EducationSubTitle")]
        public string EducationSubTitle { get; set; }

        [BsonElement("EducationStartDate")]
        public DateTime EducationStartDate { get; set; }

        [BsonElement("EducationEndDate")]
        public DateTime EducationEndDate { get; set; }

        [BsonElement("EducationDetail")]
        public string EducationDetail { get; set; }

        [BsonElement("EducationStatus")]
        public byte EducationStatus { get; set; }

        [BsonElement("ContentFileID")]
        public string ContentFileID { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
