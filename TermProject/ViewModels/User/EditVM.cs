using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TermProject.ViewModels.User
{
    public class EditVM
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "*Name is Required!")]
        public string Name { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "*Username is Required!")]
        public string Username { get; set; }
            [DisplayName("Mail")]
        [Required(ErrorMessage = "*Email is Required!")]
        public string Email { get; set; }
       
        [DisplayName(" new Password")]
        [Required(ErrorMessage = "*Enter your  new paassword !")]
        public string Password { get; set; }
        [DisplayName(" old Password")]
        [Required(ErrorMessage = "*Enter your old paassword !")]
        public string OldPassword { get; set; }

    }
}
