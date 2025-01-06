using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Repositories;
using TermProject.Entities;
using TermProject.Extensions;
using TermProject.Filters;
using TermProject.ViewModels.User;
using TermProject.ViewModels;
using System.Linq.Expressions;


namespace TermProject.Controllers
{
    [Auth]
    public class UserController : Controller
    {
        TermProjectDbContext context = new TermProjectDbContext();

       
        public IActionResult Index()
        {

           
            return View();
        }
        [HttpGet]
        public IActionResult UserEdit()
        {
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

           
            Users? item = context.Users.SingleOrDefault(u => u.Id == loggedUser.Id);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

        
            EditVM model = new EditVM
            {
                Id = item.Id,
                Username = item.Username,
                Password = item.Password,
                Name = item.Name,
                Email = item.Email
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UserEdit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Users loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            Users? item = context.Users.SingleOrDefault(u => u.Id == loggedUser.Id);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (model.OldPassword != item.Password)
            {
                ViewData["PasswordError"] = "The old password is incorrect.";
                return View(model); 
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                item.Password = model.Password; 
            }

            item.EditUser(model);    
            context.Users.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
