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
        //Метод, който извежда всички рецепти от базата данни
        public List<Recipe> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Recipes.Include(pr => pr.ProductsRecipes).ThenInclude(p => p.Product).ToList();
                return dbContext.Recipes.Include(rt => rt.RecipeType).ToList();
            }
        }
        //Метод, който намира и връща рецепта от базата данни по нейното ИД
        public Recipe Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Recipes.Find(id);
            }
        }
        //Метод, който добавя рецепта в базата данни
        public void Add(Recipe recipe)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Recipes.Add(recipe);
                dbContext.SaveChanges();
            }
        }
        //Метод, който актуализира данните за рецепта, която вече съществува в базата данни
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
        //Метод, който намира и изтрива рецепта от базата данни по нейното ИД
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
        //Метод, който сортира всички рецепти в базата данни във възходящ ред на тяхната калоричност
        public List<Recipe> SortByCalories(List<Recipe> recipes)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return recipes.OrderBy(x => x.Kcal).ToList();
            }
        }
        //Метод, който намира и извежда всички рецепти от даден тип
        public List<Recipe> GetAllByType(List<Recipe> recipes, string type)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                int id = recipeTypeController.GetByName(type);
                return recipes.Where(x => x.TypeId == id).ToList();
            }
        }
        //Метод, който сортира и връща пет рецепти в низходящ ред на техния рейтинг
        public List<Recipe> Top5ByRating(List<Recipe> recipes)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return recipes.OrderByDescending(x => x.Rating).Take(5).ToList();
            }
        }
        //Метод, който изчислява сбора от цените на всички продукти в една рецепта (цената на рецептата за една порция)
        public double CalculatePrice(Recipe recipe)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                double totalPrice = 0;
                List<string> products = this.GetProductsByRecipe(recipe.Name);
                foreach (var item in products)
                {
                    Product product = productController.GetByName(item);
                    totalPrice += product.Price;
                }
                return totalPrice;
            }
        }
        //Метод, който намира и извежда дадена рецепта по нейното име
        public Recipe GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First();
        }
        //Метод, който намира и извежда иммената на всички продукти, участващи в една рецепта
        public List<string> GetProductsByRecipe(string recipeName)
        {
            Recipe recipe = this.GetByName(recipeName);
            List<int> productIDs = new List<int>();
            List<string> productsByRecipe = new List<string>();
            List<Product_Recipe> pr = recipe.ProductsRecipes.ToList();
            foreach (var item in pr)
            {
                productIDs.Add(item.ProductId);
            }
            foreach (var item in productIDs)
            {
                productsByRecipe.Add(productController.Get(item).Name);
            }
            return productsByRecipe;
        }
        //Метод, който добавя данни в свързващата таблица
        public void AddProductRecipe(Product_Recipe pr)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Products_Recipes.Add(pr);
                dbContext.SaveChanges();
            }
        }
    }
}
