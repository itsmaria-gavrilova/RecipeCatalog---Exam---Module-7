using Data;
using Data.Models;
using Business;

namespace TestProductController
{
    //gergana
    public class Tests
    {
        [Test]
        public void MethodGetAllReturnsAllProducts()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void MethodGetReturnsProductById()
        {
            // Arrange
            ProductController controller = new ProductController();
            int id = 8;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void MethodAddAddsNewProduct()
        {
            // Arrange
            ProductController controller = new ProductController();
            Product product = new Product();
            product.Name = "TestName";
            product.Price = 1.2;

            // Act
            controller.Add(product);
            int id = controller.GetByName("TestName").Id;
            var result = controller.Get(id);
            //Assert
            Assert.AreEqual("TestName", result.Name);
        }

        [Test]
        public void MethodUpdateUpdatesProductData()
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
        public void MethodDeleteDeletesProductById()
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

        [Test]
        public void MethodGetByNameReturnsProductByProductName()
        {
            // Arrange
            ProductController controller = new ProductController();
            string name = "TestName";

            // Act
            var result = controller.GetByName(name);

            // Assert
            Assert.AreEqual(16, result.Id);
        }
    }
}