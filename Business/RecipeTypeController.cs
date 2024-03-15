using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RecipeTypeController
    {
        private RecipeCatalogDbContext dbContext;
        public List<RecipeType> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.RecipeTypes.ToList();
            }
        }
        public RecipeType Get(string name)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.RecipeTypes.Find(name);
            }
        }
        public void Add(RecipeType recipeType)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.RecipeTypes.Add(recipeType);
                dbContext.SaveChanges();
            }
        }
        public void Update(RecipeType recipeType)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var item = dbContext.RecipeTypes.Find(recipeType.Id);
                if (item != null)
                {
                    dbContext.Entry(item).CurrentValues.SetValues(recipeType);
                    dbContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var recipeType = dbContext.RecipeTypes.Find(id);
                if (recipeType != null)
                {
                    dbContext.RecipeTypes.Remove(recipeType);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
