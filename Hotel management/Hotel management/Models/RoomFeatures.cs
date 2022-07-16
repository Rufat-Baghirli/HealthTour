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
        public int RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }
        public RoomFeaturesTranslation? RoomFeaturesTranslation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
