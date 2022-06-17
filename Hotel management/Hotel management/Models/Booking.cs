using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]


        public DateTime Checkin { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]


        public DateTime Checkout { get; set; }
        [Display(Name = "Hotel")]
        public Hotel Hotel { get; set; }
        public DateTime ReserveTime { get; set; } = DateTime.Now;
        public int Night { get; set; }
        [EmailAddress, DataType(DataType.EmailAddress),Display(Name="Email")]
         public string? Email { get; set; }
        [Phone, DataType(DataType.PhoneNumber)]
         public string? PhoneNumber { get; set; }
       [Display(Name= "Name")]
         public string? Name { get; set; }
        [Display(Name = "Surname")]
        public string? SurName { get; set; }
        public int Child { get; set; }
        public int Adult { get; set; }
        public int Guest { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        public string? Ordernumber { get; set; }

        public List<Adult>Adults { get; set; }

        public List<Child>? Children { get; set; }

        public bool IsDeleted { get; set; }
        [NotMapped]
        public int[] AdultsItems { get; set; }
        [NotMapped]
        public int[] ChildrenItems { get; set; }

        

        


    }
}
