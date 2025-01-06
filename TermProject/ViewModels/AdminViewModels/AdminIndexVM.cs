using TermProject.Entities;
using TermProject.ViewModels.Shared;



namespace TermProject.ViewModels.AdminViewModels
{
    

    
        public class AdminIndexVM
        {
        public FilterVM Filter { get; set; }
        public PagerVM Pager { get; set; }
        public List<Users> Items { get; set; }
     
    }
    
}
