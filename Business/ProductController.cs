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
        public List<Product> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products.ToList();
            }
        }
        public Product Get(string name)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.Products.Find(name);
            }
        }
        public void Add(Product product)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
        }
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
    }
}
