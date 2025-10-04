using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
         public string Description { get; set; }
    }
}
