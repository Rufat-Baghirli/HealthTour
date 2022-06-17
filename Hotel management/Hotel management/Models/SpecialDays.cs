using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class SpecialDays
    {
        public int Id { get; set; }
        public double Price { get; set; }
       public RoomType? RoomType { get; set; }
        public int RoomTypeId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
       
        public DateTime Start { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]

        public DateTime End { get; set; }


    }
}
