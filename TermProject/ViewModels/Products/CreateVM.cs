using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TermProject.ViewModels.Products
{
    public class CreateVM
    {
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "*Product name is Required!")]
        public string ProductName { get; set; }
        [DisplayName("Product Description")]
        [Required(ErrorMessage = "*Product  description is Required!")]
        public string ProductDescription { get; set; }
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "*Product price is Required!")]
        public int ProductPrice { get; set; }
        [DisplayName("Category")]
        [Required(ErrorMessage = "*Product category is Required!")]
        public string ProductCategoryId { get; set; }

        [DisplayName("ImagePath")]
        [Required(ErrorMessage = "*Image  is Required!")]
        public IFormFile ImagePath { get; set; }
    }
}
