using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class Treatment
    {
        [Key]
        public int? Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public TreatmentTranslations? TreatmentTranslations { get; set; }



    }
}
