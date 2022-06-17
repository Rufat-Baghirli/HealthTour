
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel_management.Models
{
    public class HotelStars
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int? Star { get; set; }
       
    }
}
