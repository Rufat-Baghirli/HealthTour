using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_management.Models
{
    public class Child
    {


        //public int Id { get; set; }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Range(0, 17)]
        public int Age { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        public Treatment? Treatment_model { get; set; }
        public int? Treatment_modelId { get; set; } 
        public bool Treatment { get; set; }



    }
}
