using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class TourTranslations
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(100), MinLength(8)]
        public string Name_en { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(100), MinLength(8)]
        public string Name_ru { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(1024), MinLength(8)]
        public string Description_en { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(1024), MinLength(8)]
        public string Description_ru { get; set; }
        public Tour? Tour { get; set; }
        public int TourId { get; set; }
    }
}
