using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Hotel_management.DAL;

namespace Hotel_management.Models
{
    public class Adult
    {

        [Key]
        public Guid Id { get; set; }
       
        [Display(Name ="Price")]
        public double Price { get; set; }
        public bool Treatment { get; set; }

        public Treatment? Treatment_model { get; set; }
        public int? Treatment_modelId { get; set; } 
	

    }
}
