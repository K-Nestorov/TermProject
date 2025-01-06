using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Entities
{
    public class Cart : BaseEntity
    {
        // Foreign key for the User
        [ForeignKey("User")]  // Specifies that UserId is the foreign key for the User navigation property
        public int UserId { get; set; }
        public Users User { get; set; } // Navigation property

        // Foreign key for the Product
        [ForeignKey("Product")]  // Specifies that ProductId is the foreign key for the Product navigation property
        public int ProductId { get; set; }
        public Products Product { get; set; } // Navigation property

        public int Quantity { get; set; }
    }
}
