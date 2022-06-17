using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class HotelImages
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel? Hotel { get; set; }
      
    }
}
