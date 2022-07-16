using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class RoomImages
    {
        
   
            public int Id { get; set; }
            [Required]
            [StringLength(255)]
            public string Name { get; set; }
            public int? RoomId { get; set; }
        public virtual RoomType? Room { get; set; }


    }

}

