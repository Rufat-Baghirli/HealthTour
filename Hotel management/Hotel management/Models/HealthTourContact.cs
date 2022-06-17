using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class HealthTourContact
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Facebook { get; set; }
        [StringLength(100)]
        public string Instagram { get; set; }
        [StringLength(100)]
        public string Whatsapp { get; set; }
        [StringLength(100)]
        public string Twitter { get; set; }
        [StringLength(100)]
        public string Linkedin { get; set; }
        [StringLength(100), EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

    }
}
