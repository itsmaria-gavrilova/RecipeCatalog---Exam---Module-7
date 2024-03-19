using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductTypeController
    {
        private RecipeCatalogDbContext dbContext;
        //Метод, който извежда всички типове продукти в базата данни
        public List<ProductType> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.ProductTypes.ToList();
            }
        }
        //Метод, който намира и извежда тип продукт в базата данни по неговото ИД
        public ProductType Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.ProductTypes.Find(id);
            }
        }
        //Метод, който добавя тип продукт в базата данни
        public void Add(ProductType productType)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.ProductTypes.Add(productType);
                dbContext.SaveChanges();
            }
        }
        //Метод, който намира и изтрива продукт от базата данни по неговото ИД
        public void Delete(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var productType = dbContext.ProductTypes.Find(id);
                if (productType != null)
                {
                    dbContext.ProductTypes.Remove(productType);
                    dbContext.SaveChanges();
                }
            }
        }
        //Метод, който намира и извежда тип продукт от базата данни по неговото име
        public int GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First().Id;
        }
    }
