using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class RoomFeatureDetail
    {
        public int Id { get; set; }
        [Required]
        public string Detail { get; set; }
        public int RoomFeaturesId { get; set; }
        public RoomFeatures? RoomFeatures { get; set; }
        public RoomFeatureDetailTranslations? RoomFeatureDetailTranslations { get; set; }     
    }
}
