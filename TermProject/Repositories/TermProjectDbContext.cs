using Microsoft.EntityFrameworkCore;
using TermProject.Entities;


namespace ProjectManagement.Repositories
{
    public class TermProjectDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
     
        public TermProjectDbContext()
        {
            this.Users = this.Set<Users>();
            this.Products = this.Set<Products>();
            this.Carts = this.Set<Cart>();
        
       

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-FMTVKQC;Database=TermProjectDB;Trusted_Connection=True;TrustServerCertificate=True;");


        }

    }
}
