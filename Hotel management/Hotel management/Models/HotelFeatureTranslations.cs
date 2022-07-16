namespace Hotel_management.Models
{
    public class HotelFeatureTranslations
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public int HotelFeatureId { get; set; }
        public HotelFeature? HotelFeature { get; set; }
    }
}
