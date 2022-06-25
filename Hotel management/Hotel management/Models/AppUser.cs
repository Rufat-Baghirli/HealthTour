using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class AppUser:IdentityUser
    {
        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        public string SurName { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
