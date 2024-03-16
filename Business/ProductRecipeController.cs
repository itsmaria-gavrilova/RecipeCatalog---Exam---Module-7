using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductRecipeController
    {
        private RecipeCatalogDbContext dbContext;
        public List<Product_Recipe> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products_Recipes.ToList();
            }
        }
        public Product_Recipe Get(int productId,int recipeId)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products_Recipes.Find(productId,recipeId);
            }
        }
        public void Add(Product_Recipe pr)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Products_Recipes.Add(pr);
                dbContext.SaveChanges();
            }
        }
        public void Delete(int productId, int recipeId)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var pr = dbContext.Products.Find(productId, recipeId);
                if (pr != null)
                {
                    dbContext.Products.Remove(pr);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
