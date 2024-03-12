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
    public class RecipeController
    {
        private RecipeCatalogDbContext dbContext;
        public List<Recipe> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.ToList();
            }
        }
        public void Delete(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var recipe = dbContext.Recipes.Find(id);
                if (recipe != null)
                {
                    dbContext.Recipes.Remove(recipe);
                    dbContext.SaveChanges();
                }
            }
        }
        public Recipe GetByName(string name)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.Find(name);
            }
        }
        public void Add(Recipe recipe)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Recipes.Add(recipe);
                dbContext.SaveChanges();
            }
        }
        public void Update(Recipe recipe)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var item = dbContext.Recipes.Find(recipe.Name);
                if (item != null)
                {
                    dbContext.Entry(item).CurrentValues.SetValues(recipe);
                    dbContext.SaveChanges();
                }
            }
        }
        public void SortByCalories()
        {
            using(dbContext=new RecipeCatalogDbContext())
            {
                dbContext.Recipes.OrderBy(x => x.Kcal);
                dbContext.SaveChanges();
            }
        }
        public List<Recipe> GetAllByType(string type)
        {
            using(dbContext = new RecipeCatalogDbContext())
            {
                int id = dbContext.RecipeTypes.Find(type).Id;
                return dbContext.Recipes.Where(x => x.TypeId == id).ToList();
            }
        }
        public List<Recipe> Top5ByRating()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                List<Recipe> sortedRecipes = dbContext.Recipes.OrderByDescending(x => x.Rating).ToList();
                List<Recipe> top5ByRating = new List<Recipe>();
                for (int i = 0; i < 5; i++)
                {
                    top5ByRating.Add(sortedRecipes[i]);
                }
                return top5ByRating;
            }
        }
        public double CalculatePrice(Recipe recipe)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                double totalPrice = 0;
                List<Product_Recipe> recipeProducts = dbContext.Products_Recipes.Where(x => x.RecipeId == recipe.Id).ToList();
                for (int i = 0; i < recipeProducts.Count; i++)
                {
                    List<Product> products = dbContext.Products.Where(x => x.Id == recipeProducts[i].ProductId).ToList();
                    for (int j = 0; j < products.Count; j++)
                    {
                        totalPrice += products[j].Price;
                    }
                }
                return totalPrice;
            }
        }
    }
}
