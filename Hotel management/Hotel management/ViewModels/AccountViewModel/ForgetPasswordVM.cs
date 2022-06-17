using System.ComponentModel.DataAnnotations;

namespace Hotel_management.ViewModels.AccountViewModel
{
    public class ForgetPasswordVM
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
