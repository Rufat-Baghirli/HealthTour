using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class TreatmentTranslations
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name_en { get; set; }
        [StringLength(100)]
        public string Name_ru { get; set; }
        [StringLength(255)]
        public string Description_en { get; set; }
        [StringLength(255)]
        public string Description_ru { get; set; }
        public Treatment? Treatment { get; set; }
        public int TreatmentId { get; set; }
    }
}
