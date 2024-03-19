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
        //Метод, който връща всички типове рецепти в базата данни
        public List<RecipeType> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.RecipeTypes.ToList();
            }
        }
        //Метод, който намира и извежда тип рецепта от базата данни по неговото ИД
        public RecipeType Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.RecipeTypes.Find(id);
            }
        }
        //Метод, който добавя тип рецепта в базата данни
        public void Add(RecipeType recipeType)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.RecipeTypes.Add(recipeType);
                dbContext.SaveChanges();
            }
        }
        //Метод, който изтрива тип рецепта от базата данни по неговото ИД
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
        //Метод, който намира и извежда тип рецепта по неговото име
        public int GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First().Id;
        }
    }
}
