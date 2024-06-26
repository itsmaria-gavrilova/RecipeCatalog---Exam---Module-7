﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Kcal { get; set; }
        [Required]
        public string Description { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(RecipeType))]
        public int TypeId { get; set; }
        public RecipeType RecipeType { get; set; }
        public ICollection<Product_Recipe> ProductsRecipes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}