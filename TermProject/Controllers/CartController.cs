using Microsoft.AspNetCore.Mvc;
using TermProject.Entities;
using TermProject.Extensions;
using TermProject.ViewModels.Cart;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Repositories;

namespace TermProject.Controllers
{
    public class CartController : Controller
    {
       TermProjectDbContext _context=new TermProjectDbContext();

        public IActionResult Index()
        {
            // Retrieve the logged-in user from session
            Users loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Retrieve the user's cart items from the database
            var cartItems = _context.Carts
                .Where(c => c.UserId == loggedUser.Id)
                .Include(c => c.Product) // Ensure product details are included
                .Select(c => new CartItemVM
                {
                    ProductId = c.ProductId,
                    ProductName = c.Product.ProductName,
                    ImagePath = c.Product.ImagePath,
                    ProductPrice = c.Product.ProductPrice,
                    UserId = c.UserId
                })
                .ToList();

            // Create the ViewModel
            var model = new IndexVM
            {
                Items = cartItems
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(int clickedId)
        {
            // Retrieve the logged-in user from session
            Users loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Retrieve the product based on clickedId
            var product = _context.Products.FirstOrDefault(p => p.Id == clickedId);

            if (product == null)
            {
                ModelState.AddModelError("", "Product not found.");
                return RedirectToAction("Index", "Home");
            }

            // Check if the product is already in the user's cart
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.ProductId == clickedId && c.UserId == loggedUser.Id);

            if (existingCartItem == null)
            {
                // Add the new item to the cart
                var newCartItem = new Cart
                {
                    UserId = loggedUser.Id,
                    ProductId = product.Id
                };

                _context.Carts.Add(newCartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult Delete(int productId,int UserId)
        {
            // Retrieve the logged-in user from session
            Users loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Find the cart item for the logged-in user
            var cartItem = _context.Carts
                .FirstOrDefault(c => c.UserId == loggedUser.Id && c.ProductId == productId);
            if (cartItem == null)
            {
                // Optionally, handle the case when the item is not found
                return RedirectToAction("Index");
            }

            // Remove the cart item
            _context.Carts.Remove(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
