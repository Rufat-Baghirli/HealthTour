using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class HotelFeature
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<HotelFeatureDetails> HotelFeatureDetails { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public HotelFeatureTranslations? HotelFeatureTranslations { get; set; }
        public bool IsDeleted { get; set; }




    }
}
