using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TermProject.ViewModels.Register
{
    public class RegisterVM
    {
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "*Name is Required!")]
        public string Name { get; set; }
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*Username is Required!")]
        public string Username {  get; set; }
        [DisplayName("Email: ")]
        [Required(ErrorMessage = "*Email is Required!")]
        public string Email {  get; set; }
        [DisplayName("Password: ")]
        [Required(ErrorMessage = "*Password is Required!")]
        public string Password { get; set; }
        public string Role { get; set; }
       
    }
}
