using System.ComponentModel.DataAnnotations;

namespace NorthernProducts.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
