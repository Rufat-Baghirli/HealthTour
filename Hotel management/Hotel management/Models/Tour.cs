using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(100),MinLength(8)]
        public string Name { get; set; }
        public string Img { get; set; }
        [Required(ErrorMessage ="Bos buraxila bilmez."), StringLength(1024), MinLength(8)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public bool IsXarici { get; set; }

        [NotMapped]
        public IFormFile Imagefile { get; set; }

        public bool IsDeleted { get; set; }
        public TourTranslations? TourTranslations { get; set; }
    }
}
