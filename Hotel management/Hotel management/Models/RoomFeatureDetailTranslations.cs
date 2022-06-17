namespace Hotel_management.Models
{
    public class RoomFeatureDetailTranslations
    {
        public int Id { get; set; }
        public string Detail_en { get; set; }
        public string Detail_ru { get; set; }
        public int RoomFeatureDetailId { get; set; }
        public RoomFeatureDetail RoomFeatureDetail { get; set; }
    }
}
