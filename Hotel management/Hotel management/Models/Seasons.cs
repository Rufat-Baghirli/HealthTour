using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Seasons
    {
        [Key]
        public int Id { get; set; }
        public Hotel? Hotel { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public HighSeason? HighSeason { get; set; }
        public MidSeason? MidSeason { get; set; }
        public LowSeason? LowSeason { get; set; }


    }
}
