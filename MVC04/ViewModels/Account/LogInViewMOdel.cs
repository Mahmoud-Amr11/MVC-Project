using System.ComponentModel.DataAnnotations;

namespace MVC04.ViewModels.Account
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)] 
        
        public string Password { get; set; }

       
        public bool RememberMe { get; set; }
    }
}
