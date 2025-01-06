using TermProject.Entities;
using TermProject.ViewModels.AdminViewModels;
using TermProject.ViewModels.Shared;


namespace TermProject.ViewModels.Products
{
    public class IndexVM
    {
        public FilterProductsVM FilterProductsVM { get; set; }
        public FilterVM Filter {  get; set; }
        public PagerVM Pager { get; set; }
        public List<TermProject.Entities.Products> Items { get; set; }
 
    }
}
