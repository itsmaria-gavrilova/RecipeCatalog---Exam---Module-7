using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;
using Data.Models;

namespace Business
{
    public class ProductController
    {
        private RecipeCatalogDbContext dbContext;
        //Метод, който връща всички продукти в базата данни
        public List<Product> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products.ToList();
            }
        }
        //Метод, който намира и връща продукт по неговото ИД
        public Product Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products.Find(id);
            }
        }
        //Метод, който добавя продукт в базата данни
        public void Add(Product product)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
        }
        //Метод, който актуалицира информацията за продукт, който вече съществува в базата данни
        public void Update(Product product)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var item = dbContext.Products.Find(product.Id);
                if (item != null)
                {
                    dbContext.Entry(item).CurrentValues.SetValues(product);
                    dbContext.SaveChanges();
                }
            }
        }
        //Метод, който намира и изтрива продукт от базата данни по неговото ИД
        public void Delete(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                var product = dbContext.Products.Find(id);
                if (product != null)
                {
                    dbContext.Products.Remove(product);
                    dbContext.SaveChanges();
                }
            }
        }
        public Product GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First();
        }
    }
}
