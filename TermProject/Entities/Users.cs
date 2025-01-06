using Microsoft.AspNetCore.Mvc;
using TermProject.ViewModels.AdminViewModels;
using TermProject.ViewModels.Products;
using TermProject.ViewModels.Register;
using TermProject.ViewModels.User;

namespace TermProject.Entities
{
    public class Users:BaseEntity
    {
   
        public string Name { get; set; }
        public string Username {  get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }
        public Users()
        {

        }
        public Users(RegisterVM model)
        {
            this.Username = model.Username;
            this.Password = model.Password;
            this.Email = model.Email;
            this.Name = model.Name;
            this.Role = model.Role;
            
        }
        public void AdminEditUsers(AdminEditVM model)
        {
            this.Username = model.Username;
            this.Role = model.Role;
            this.Name = model.Name;
            this.Email = model.Email;
        }
        public void RegisterUser(RegisterVM model)
        {
           this.Username = model.Username;
           this.Password = model.Password;
           this.Email = model.Email;
           this.Name = model.Name;
           this.Role = "User";               
        }
        public void EditUser(TermProject.ViewModels.User.EditVM model) {

            this.Username = model.Username;
            this.Name = model.Name;
            this.Email = model.Email;
        }
    }
    
}
