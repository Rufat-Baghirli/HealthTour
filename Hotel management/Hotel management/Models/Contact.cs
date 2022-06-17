using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        [Required,StringLength(30)]
        public string FirstName { get; set; }
        [Required, StringLength(30)]
        public string LastName { get; set; }
        [Required, StringLength(16), Phone, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required,StringLength(100),EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(30)]
        public string City { get; set; }
        [Required, StringLength(1024)]
        public string Description { get; set; }

    }
}
