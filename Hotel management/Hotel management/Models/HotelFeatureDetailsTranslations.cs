namespace Hotel_management.Models
{
    public class HotelFeatureDetailsTranslations
    {
        public int Id { get; set; }
        public string Detail_en { get; set; }
        public string Detail_ru { get; set; }
        public int HotelFeatureDetailsId { get; set; }
        public HotelFeatureDetails? HotelFeatureDetails { get; set; }
    }
}
