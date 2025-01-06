using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TermProject.ViewModels.Login
{
    public class LoginVM
    {
        [DisplayName("Username:")]
       
        [Required(ErrorMessage = "*Username is Required!")]
        public string Username { get; set; }
        [DisplayName("Password:")]
        [Required(ErrorMessage = "*Password is Required!")]
        public string Password { get; set; }
    }
}
