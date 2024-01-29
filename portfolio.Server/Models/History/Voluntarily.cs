namespace portfolio.Server.Models.History
{
    [BsonIgnoreExtraElements]
    public class Voluntarily
    {
        public Voluntarily() => Id = Guid.NewGuid();

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("VoluntarilyTitle")]
        public string VoluntarilyTitle { get; set; }

        [BsonElement("VoluntarilySubTitle")]
        public string VoluntarilySubTitle { get; set; }

        [BsonElement("VoluntarilyStartDate")]
        public DateTime VoluntarilyStartDate { get; set; }

        [BsonElement("VoluntarilyEndDate")]
        public DateTime VoluntarilyEndDate { get; set; }

        [BsonElement("VoluntarilyDetail")]
        public string VoluntarilyDetail { get; set; }

        [BsonElement("VoluntarilyStatus")]
        public byte VoluntarilyStatus { get; set; }

        [BsonElement("ContentFileID")]
        public string ContentFileID { get; set; }

        [BsonElement("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
