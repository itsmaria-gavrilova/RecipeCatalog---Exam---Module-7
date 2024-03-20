using Data;
using Data.Models;
using Business;

namespace TestProductController
{
    //gergana
    public class Tests
    {
        [Test]
        public void Method1GetAllReturnsAllProducts()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void Method2GetReturnsProductById()
        {
            // Arrange
            ProductController controller = new ProductController();
            int id = 2;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Method3AddAddsNewProduct()
        {
            // Arrange
            ProductController controller = new ProductController();
            Product product = new Product();
            product.Name = "TestName";
            product.Price = 1.2;
            product.TypeId = 2;

            // Act
            controller.Add(product);
            int id = controller.GetByName("TestName").Id;
            var result = controller.Get(id);
            //Assert
            Assert.AreEqual("TestName", result.Name);
        }

        [Test]
        public void Method4UpdateUpdatesProductData()
        {
            // Arrange
            ProductController controller = new ProductController();
            int id = controller.GetByName("TestName").Id;
            var updatedProduct = controller.Get(id);
            updatedProduct.Name = "Updated Name";

            // Act
            controller.Update(updatedProduct);
            var result = controller.Get(id);

            // Assert
            Assert.AreEqual("Updated Name", result.Name);
        }

        [Test]
        public void Method5DeleteDeletesProductById()
        {
            // Arrange
            ProductController controller = new ProductController();
            int id = controller.GetByName("Updated Name").Id;

            // Act
            controller.Delete(id);
            var result = controller.Get(id);

            // Assert
            Assert.Null(result);
        }
    }
}