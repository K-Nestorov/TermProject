using System.ComponentModel.DataAnnotations;

namespace TermProject.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id {  get; set; }
    }
}
