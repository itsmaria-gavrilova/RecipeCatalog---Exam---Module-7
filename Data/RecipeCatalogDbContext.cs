using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Models;


namespace Data
{
    public class RecipeCatalogDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<Product_Recipe> Products_Recipes { get; set; }

        public RecipeCatalogDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;Database=RecipeCatalogDB;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Recipe>().HasKey(pr => new { pr.ProductId, pr.RecipeId });
        }
    }
}

