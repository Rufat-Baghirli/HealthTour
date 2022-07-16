using Hotel_management.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotel_management.ViewModels.SearchRoomViewModel
{
    public class SearchRoomVM
    {
        [Required(ErrorMessage = "The hotel or city name must be entered")]
        [StringLength(50)]
        public string Location { get; set; }
        [Required(ErrorMessage = "Check-in date must be entered")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]

        public DateTime Checkin { get; set; }
        [Required(ErrorMessage = "Checkout date must be entered")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]

        public DateTime Checkout { get; set; }

 
        public Review? Reviews { get; set; }
         
        public List<Hotel>?Hotels { get; set; }

        [Range(1,12)]
        public List<int>?LowMonthvalues { get; set; }
        [Range(1, 12)]
        public List<int>? MidMonthvalues { get; set; }
        [Range(1, 12)]
        public List<int>? HighMonthvalues { get; set; }
        public List<Adult>Adults { get; set; }
        public List<Child>? Childs { get; set; }








    }
}
