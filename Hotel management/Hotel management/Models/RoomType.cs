using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class RoomType
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq secilmelidir!")]
        [Display(Name = "Type")]
        public string? Name { get; set; }
        [Required]
        public double OneweekPrice { get; set; }
        [Required]
        public double TwoweeksPrice { get; set; }
        [Required]
        public double ThreeweeksPrice { get; set; }
        [Required]
        public double OneweekPriceMid { get; set; }
        [Required]
        public double TwoweeksPriceMid { get; set; }
        [Required]
        public double ThreeweeksPriceMid { get; set; }
        [Required]
        public double OneweekPriceHigh { get; set; }
        [Required]
        public double TwoweeksPriceHigh { get; set; }
        [Required]
        public double ThreeweeksPriceHigh { get; set; }
        public Hotel? Hotel { get; set; }
        public int? HotelId { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<SpecialDays>? SpecialDays { get; set; }
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Sekil mutleq secilmelidir")]
        [NotMapped]
        public IFormFile MainimgFile { get; set; }
        public IEnumerable<Booking>? Bookings { get; set; }

        public IEnumerable<RoomFeatures>? RoomFeatures { get; set; }
        public float Roomarea { get; set; }
        [StringLength(255)]
        public string? Mainimg { get; set; }
        public virtual ICollection<RoomImages>? RoomImages { get; set; }

        [NotMapped]
        public IFormFile[]? RoomImagesFile { get; set; }
        public int People { get; set; }
        public int Children { get; set; }



    }
}
