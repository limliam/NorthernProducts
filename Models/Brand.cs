using System.ComponentModel.DataAnnotations;

namespace NorthernProducts.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Brand")]

        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
