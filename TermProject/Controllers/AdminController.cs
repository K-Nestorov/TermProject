using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Repositories;
using System.Linq.Expressions;
using TermProject.Entities;
using TermProject.Extensions;
using TermProject.Filters;
using TermProject.ViewModels;
using TermProject.ViewModels.AdminViewModels;
using TermProject.ViewModels.Products;
using TermProject.ViewModels.Register;
using TermProject.ViewModels.Shared;

namespace TermProject.Controllers
{
    [Auth]
   [Admin]

    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        TermProjectDbContext context = new TermProjectDbContext();

        
        public IActionResult Index(AdminIndexVM model)
        {
            //posle
            model.Filter = model.Filter ?? new FilterVM();

            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                        ? 1
                                        : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 10
                                        : model.Pager.ItemsPerPage;

            Expression<Func<Users, bool>> filter = u =>
              (string.IsNullOrEmpty(model.Filter.Username) || u.Username.Contains(model.Filter.Username)) &&
              (string.IsNullOrEmpty(model.Filter.Name) || u.Name.Contains(model.Filter.Name));
             

            model.Pager.PagesCount = (int)Math.Ceiling(context.Users.Where(filter).Count() / (double)model.Pager.ItemsPerPage);

            model.Items = context.Users
                                    .OrderBy(i => i.Id)
                                    .Where(filter)
                                    .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                    .Take(model.Pager.ItemsPerPage)
                                    .ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public IActionResult CreateUser(RegisterVM model)
        {
            if (!ModelState.IsValid)

                return View(model);

            Users item = new Users(model);
          
            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public IActionResult AdminEdit(int id)
        {
            Users? item=context.Users.Where(u=>u.Id == id).FirstOrDefault();
            if (item==null)
            {
                return RedirectToAction("Index", "Admin");

            }
            AdminEditVM model = new AdminEditVM
            {
                Id = item.Id,
                Username = item.Username,
                Role = item.Role,
                Email = item.Email,
                Name = item.Name,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AdminEdit(AdminEditVM model)
        {

           
            // Retrieve the existing user
            Users? item = context.Users.FirstOrDefault(u => u.Id == model.Id);
            if (item == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            // Update properties
            item.AdminEditUsers(model);

            // Save changes
            context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult Delete(int id)
        {
            Users item = new Users();
            item.Id = id;
            Cart cart=new Cart();
            context.Users.Remove(item);
            context.SaveChanges();
            
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult AdminProduct(IndexVM model)
        {
            //posle
            model.Filter = model.Filter ?? new FilterVM();

            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                        ? 1
                                        : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 10
                                        : model.Pager.ItemsPerPage;

            Expression<Func<Products, bool>> filter = u =>
              (string.IsNullOrEmpty(model.Filter.ProductName) || u.ProductName.Contains(model.Filter.ProductName)) &&
              (string.IsNullOrEmpty(model.Filter.ProductDescription) || u.ProductDescription.Contains(model.Filter.ProductDescription));


            model.Pager.PagesCount = (int)Math.Ceiling(context.Products.Where(filter).Count() / (double)model.Pager.ItemsPerPage);

            model.Items = context.Products
                                    .OrderBy(i => i.Id)
                                    .Where(filter)
                                    .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                    .Take(model.Pager.ItemsPerPage)
                                    .ToList();

            return View(model); 
        }
        [HttpGet]  
        public IActionResult AdminProductEdit(int id)
        {
            Products? item = context.Products.Where(u => u.Id ==id ).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("AdminProduct", "Admin");

            }
            EditVM model = new EditVM() {
                Id = item.Id,
                ProductName = item.ProductName,
                ProductPrice = item.ProductPrice,
                ProductDescription = item.ProductDescription,
                ImagePath = item.ImagePath,
                ProductCategoryId = item.ProductCategoryId,
            };
            return View(model);

           
        }
        [HttpPost]
        public IActionResult AdminProductEdit(EditVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            Products item = new Products(model);
          

            context.Products.Update(item);
            context.SaveChanges();

            return RedirectToAction("AdminProduct", "Admin");
        }






        public IActionResult AdminProductDelete(int id)
        {
            Products item = new Products();
            item.Id = id;

            context.Products.Remove(item);
            context.SaveChanges();
            return RedirectToAction("AdminProduct", "Admin");
        }

        [HttpGet]
        public IActionResult AdminProductCreate()
        {
          
            return View(new CreateVM());
        }
        [HttpPost]
        public IActionResult AdminProductCreate(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            string fileName = null;
            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }

          
            Products item = new Products
            {
              
                ImagePath = fileName 
            };
            item.ProductCreate(model);
            context.Products.Add(item);
            context.SaveChanges();

            return RedirectToAction("AdminProduct", "Admin");
        }




    }
}
