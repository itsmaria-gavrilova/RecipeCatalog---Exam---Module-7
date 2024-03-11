using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Product_Recipe
    {
        [Key]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Key]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public Product Product { get; set; }
        public Recipe Recipe { get; set; }
    }
}
