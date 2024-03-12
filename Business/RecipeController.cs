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

    }
}
