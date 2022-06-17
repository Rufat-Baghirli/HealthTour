using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class AboutImg
    {
        public int Id { get; set; }
        public string Img { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
