using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Business
{
    public class RecipeController
    {
        private RecipeCatalogDbContext dbContext;
        private ProductController productController = new ProductController();
        private RecipeTypeController recipeTypeController = new RecipeTypeController();
        private ProductTypeController productTypeController = new ProductTypeController();
        public List<Recipe> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Recipes.Include(pr => pr.ProductsRecipes).ThenInclude(p => p.Product).ToList();
                return dbContext.Recipes.Include(rt => rt.RecipeType).ToList();
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
        public Recipe Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.Find(id);
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
                var item = dbContext.Recipes.Find(recipe.Id);
                if (item != null)
                {
                    dbContext.Entry(item).CurrentValues.SetValues(recipe);
                    dbContext.SaveChanges();
                }
            }
        }
        public List<Recipe> SortByCalories()
        {
            using(dbContext=new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.OrderBy(x => x.Kcal).ToList();
            }
        }
        public List<Recipe> GetAllByType(string type)
        {
            using(dbContext = new RecipeCatalogDbContext())
            {
                int id=recipeTypeController.GetByName(type);
                return dbContext.Recipes.Where(x => x.TypeId == id).ToList();
            }
        }
        public List<Recipe> Top5ByRating()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.OrderByDescending(x => x.Rating).Take(5).ToList();
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
                    Product product = (Product)dbContext.Products.Where(x => x.Id == recipeProducts[i].ProductId);
                    totalPrice += product.Price;
                }
                return totalPrice;
            }
        }
        public Recipe GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First();
        }
        //public List<string> GetProductsByRecipe(string recipeName)
        //{
        //    int id = this.GetByName(recipeName);
        //    List<string> productsByRecipe = new List<string>();
        //    List<int> productIDs = new List<int>();
        //    foreach(var item in dbContext.Products_Recipes.Where(x => x.RecipeId == id).ToList())
        //    {
        //        productIDs.Add(item.ProductId);
        //    }
        //    foreach(var item in productIDs)
        //    {
        //        productsByRecipe.Add(productController.Get(item).Name);
        //    }
        //    return productsByRecipe;
        //}
    }
}
