using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class RoomFeatures
    {
        public int Id { get; set; }
        [Required]
        public string Features { get; set; }
        public IEnumerable<RoomFeatureDetail>? RoomFeatureDetails { get; set; }
        [Required(ErrorMessage ="Otaq secilmelidir")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public RoomFeaturesTranslation RoomFeaturesTranslation { get; set; }
    }
}
