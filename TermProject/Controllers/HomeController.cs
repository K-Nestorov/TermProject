using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Repositories;
using System.Diagnostics;
using TermProject.Entities;
using TermProject.Extensions;
using TermProject.Filters;
using TermProject.ViewModels.Login;
using TermProject.ViewModels.Register;
using TermProject.ViewModels.Products;
using System.Linq.Expressions;


namespace TermProject.Controllers
{
    
    public class HomeController : Controller
    {
        TermProjectDbContext context = new TermProjectDbContext();

        public IActionResult Index(IndexVM model)
        {

         
          model.Items=context.Products.ToList();

            model.FilterProductsVM ??= new FilterProductsVM();

            Expression<Func<Products, bool>> filter = u =>
                string.IsNullOrEmpty(model.FilterProductsVM.ProductName) ||
                u.ProductName.Contains(model.FilterProductsVM.ProductName);

            Expression<Func<Products, bool>> filterCategory = C =>
              string.IsNullOrEmpty(model.FilterProductsVM.ProductCategoryId) ||
              C.ProductCategoryId.Contains(model.FilterProductsVM.ProductCategoryId);






            return View(model);

        }
        [HttpGet]
        public IActionResult Login()
        {

            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
                if (loggedUser != null)
            {
                return RedirectToAction("Index" );
            }


            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            
            if (!this.ModelState.IsValid)
               return View(model);
            Users? loggedUser = context.Users.Where(u => u.Username == model.Username &&
             u.Password == model.Password).FirstOrDefault();
            if (loggedUser == null)
            {
              //  this.ModelState.AddModelError("authError", "Invalid username or password");
                return View(model);
            }
            HttpContext.Session.SetObject("loggedUser", loggedUser);
            
            return RedirectToAction("Index", "Home");
           
        }
        [HttpGet]
       public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
       

            Users item=new Users();

            item.RegisterUser(model);
            context.Users.Add(item);                       
            context.SaveChanges();

            HttpContext.Session.SetObject("loggedUser", item);            
            return RedirectToAction("Index", "Home");
        }
        
        [Auth]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Index", "Home");
        }
    }
}
