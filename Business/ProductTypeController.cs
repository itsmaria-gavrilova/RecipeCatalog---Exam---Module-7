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
        public List<ProductType> GetAll()
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.ProductTypes.ToList();
            }
        }
        public ProductType Get(int id)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                return dbContext.ProductTypes.Find(id);
            }
        }
        public void Add(ProductType productType)
        {
            using (dbContext = new RecipeCatalogDbContext())
            {
                dbContext.ProductTypes.Add(productType);
                dbContext.SaveChanges();
            }
        }
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
        public int GetByName(string name)
        {
            return this.GetAll().Where(x => x.Name == name).First().Id;
        }
    }
}
