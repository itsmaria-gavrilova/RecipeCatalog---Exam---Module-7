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
        public RecipeType Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.RecipeTypes.Find(id);
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
        public int GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First().Id;
        }
    }
}
