using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TermProject.ViewModels.AdminViewModels
{
    public class AdminEditVM
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "*Name is Required!")]
        public string Name { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "*Username is Required!")]
        public string Username { get; set; }
        [DisplayName("Mail")]
        [Required(ErrorMessage = "*Mail is Required!")]
        public string Email {  get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "*Role is Required!")]
        public string Role { get; set; }
      
        public string Password { get; set; }
    }
}
