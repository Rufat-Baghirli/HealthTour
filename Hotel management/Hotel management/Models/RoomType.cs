using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class RoomType
    {

        public enum Type
        {
            [Display(Name = "Standart Single")]
            Standart,
            [Display(Name = "Standart Double")]
            StandartDouble,
            [Display(Name = "Superior Single")]
            Superior,
            [Display(Name = "Superior Double")]
            SuperiorDouble,
            [Display(Name = "Suite Single")]
            Suite,
            [Display(Name = "Suite Double")]
            SuiteDouble,
            [Display(Name = "Deluxe")]
            Deluxe,
            [Display(Name = "King Suite")]
            KingSuite

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq secilmelidir!")]
        [Display(Name ="Type")]
        public string? Name { get; set; }
        public IEnumerable<Room>? Rooms { get; set; }
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

      
    }
}
