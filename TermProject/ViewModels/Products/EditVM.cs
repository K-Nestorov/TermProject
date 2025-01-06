using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TermProject.ViewModels.Products
{
    public class EditVM
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "*Product name is Required!")]
        public string ProductName { get; set; }
        [DisplayName("Product Description")]
        [Required(ErrorMessage = "*Product description is Required!")]
        public string ProductDescription { get; set; }
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "*Product price is Required!")]
        public int ProductPrice { get; set; }
        [DisplayName("Product Category")]
        [Required(ErrorMessage = "*Product category is Required!")]
        public string ProductCategoryId { get; set; }
        [DisplayName("Product ImagePath")]
        [Required(ErrorMessage = "*Product image is Required!")]
        public string ImagePath { get; set; }
    }
}
