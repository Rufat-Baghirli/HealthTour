using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50),MinLength(4)]
        public string Name { get; set; }
        [Required]
        [StringLength(1023), MinLength(10)]
        public string Description { get; set; }
        public string? Mainimg { get;set; }
        public virtual IEnumerable<HotelImages>? HotelImages { get; set; }
        [NotMapped]
      
        public IFormFile[]? HotelImagesFile { get; set; }
        
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<HotelFeature>? HotelFeatures { get; set; }
        //[Required]


        public IEnumerable<RoomType>? Rooms { get; set; }
        [NotMapped]
        public IFormFile MainimgFile { get; set; }
        public bool isDeleted { get; set; }
        public HotelStars? HotelStar { get; set; }
        public int HotelStarId { get; set; }
        public IEnumerable<Treatment>? Treatments{ get; set; }

        public List<Review>? Reviews { get; set; }
        public ExtraPrice? ExtraPrice { get; set; }

        public string? MapLocation { get; set; }

        public HotelTranslations? hotelTranslations { get; set; }
        public Seasons? Season { get; set; }







    }
}
