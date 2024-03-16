using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey(nameof(ProductType))]
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Product_Recipe> ProductsRecipes { get; set; }
    }
}