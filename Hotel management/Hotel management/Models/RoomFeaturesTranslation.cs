namespace Hotel_management.Models
{
    public class RoomFeaturesTranslation
    {
        public int Id { get; set; }
        public string Features_en { get; set; }
        public string Features_ru { get; set; }
        public RoomFeatures RoomFeatures { get; set; }
        public int RoomFeaturesId { get; set; }


    }
}
