using Data;
using Data.Models;
using Business;

namespace TestProductTypeController
{
    //gergana
    public class Tests
    {
        [Test]
        public void MethodGetAllReturnsAllProductTypes()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(11, result.Count);
        }

        [Test]
        public void MethodGetReturnsProductTypeById()
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
        public void MethodAddAddsNewProductType()
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
        public void MethodDeleteDeletesProductTypeById()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();
            int id = controller.GetByName("Test");

            // Act
            controller.Delete(id);
            var result = controller.Get(id);

            // Assert
            Assert.Null(result);
        }
        [Test]
        public void MethodGetByNameReturnsIdByProductTypeName()
        {
            // Arrange
            ProductTypeController controller = new ProductTypeController();
            string name = "newTest";

            // Act
            var result = controller.GetByName(name);

            // Assert
            Assert.AreEqual(15, result);
        }
    }
}