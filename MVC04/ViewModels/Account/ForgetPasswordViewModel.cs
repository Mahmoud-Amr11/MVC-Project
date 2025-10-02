using System.ComponentModel.DataAnnotations;

namespace MVC04.ViewModels.Account
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
    }
}
