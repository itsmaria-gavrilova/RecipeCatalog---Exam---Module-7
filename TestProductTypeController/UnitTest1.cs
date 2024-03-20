using Data;
using Data.Models;
using Business;

namespace TestProductTypeController
{
    //gergana
    public class Tests
    {
        [Test]
        public void Method1GetAllReturnsAllProductTypes()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(9, result.Count);
        }

        [Test]
        public void Method2GetReturnsProductTypeById()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();
            int id = 2;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Method3AddAddsNewProductType()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();
            ProductType test = new ProductType();
            test.Name = "newTest";

            // Act
            controller.Add(test);
            int id = controller.GetByName(test.Name);
            var result = controller.Get(id);

            //Assert
            Assert.AreEqual("newTest", result.Name);
        }

        [Test]
        public void Method4DeleteDeletesProductTypeById()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();
            int id = controller.GetByName("newTest");

            // Act
            controller.Delete(id);
            var result = controller.Get(id);

            // Assert
            Assert.Null(result);
        }
    }
}