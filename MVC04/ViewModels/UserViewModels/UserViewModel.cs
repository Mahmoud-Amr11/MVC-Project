using System.ComponentModel.DataAnnotations;

namespace MVC04.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string Id{ get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]

        public string LName { get; set; }

        public string Email { get; set; }
    }

}
