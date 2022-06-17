using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class HotelFeatureDetails
    {
        public int Id { get; set; }
        [Required]
        public string Detail { get; set; }
        public int HotelFeatureId { get; set; }
        public HotelFeature HotelFeature { get; set; }
        public HotelFeatureDetailsTranslations? hotelFeatureDetailsTranslations { get; set; }     
    }
}
