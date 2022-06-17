using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class TurContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.PhoneNumber)][Phone]
        public string Mobile {get;set;}
     
    }
}
