using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Models;

namespace Data
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

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Product_Recipe> ProductsRecipes { get; set; }
    }
}