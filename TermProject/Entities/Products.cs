using TermProject.ViewModels.Products;

namespace TermProject.Entities
{
    public class Products : BaseEntity
    {

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string ProductCategoryId { get; set; }
        public string ImagePath { get; set; }
        public Products()
        {

        }
        public Products(EditVM model)
        {
            this.Id = model.Id;
            this.ProductName = model.ProductName;
            this.ProductPrice = model.ProductPrice;
            this.ProductDescription = model.ProductDescription;
            this.ImagePath = model.ImagePath;
            this.ProductCategoryId = model.ProductCategoryId;
        }
        public void ProductCreate(CreateVM model)
        {
            this.ProductName = model.ProductName;
            this.ProductDescription = model.ProductDescription;
            this.ProductPrice = model.ProductPrice;
            this.ProductCategoryId = model.ProductCategoryId;
           
        }     
    }

}
