using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Otel mütləq seçilməlidir.")]
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Otaq tipi mütləq seçilməlidir.")]
        public RoomType RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public bool Smoking { get; set; }
        public IEnumerable<RoomFeatures>? RoomFeatures { get; set; }
        public float Roomarea { get; set; }
        [StringLength(255)]
        public string? Mainimg { get; set; }
        public virtual IEnumerable<RoomImages>? RoomImages { get; set; }
        
        [NotMapped]
        public IFormFile[]? RoomImagesFile { get; set; }
        public int People { get; set; }
        public int Children { get; set; }
        
        public bool isDeleted { get; set; }

        [Required(ErrorMessage ="Sekil mutleq secilmelidir")]
        [NotMapped]
        public IFormFile MainimgFile { get; set; }
        public IEnumerable<Booking>? Bookings { get; set; }

        [NotMapped]
        public double TotalPrice { get; set; }


    }
}
