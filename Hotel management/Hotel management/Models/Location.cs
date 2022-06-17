using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)][MinLength(3)]
        public string City { get; set; }
        public IEnumerable<Hotel>?Hotels { get; set; }

    }
}
