using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hotel_management.Models;

namespace Hotel_management.ViewModels
{
    public class TourDetailsVM
    {
        public string People { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(50), MinLength(3)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(1024), MinLength(8)]
        public string Details { get; set; }
        [Required(ErrorMessage = "Bos buraxila bilmez."), StringLength(100), MinLength(8)]
        public string Name { get; set; }
        public string Mainimg { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public IFormFile Imgfile { get; set; }

      

        public int TourId { get; set; }


        public TurContact? Contact { get; set; }




    }
}
