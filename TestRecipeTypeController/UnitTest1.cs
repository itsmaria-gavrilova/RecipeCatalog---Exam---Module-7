using Business;
using Data.Models;
using static NUnit.Framework.Internal.OSPlatform;

namespace TestRecipeTypeController
{
    //maria
    public class Tests
    {
        [Test]
        public void Method1GetAllReturnsAllRecipeTypes()
        {
            // Arrange
            RecipeTypeController controller = new RecipeTypeController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(11, result.Count);
        }

        [Test]
        public void Method2GetReturnsRecipeTypeById()
        {
            // Arrange
            RecipeTypeController controller = new RecipeTypeController();
            int id = 3;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Method3AddAddsNewRecipeType()
        {
            // Arrange
            RecipeTypeController controller = new RecipeTypeController();
            RecipeType test = new RecipeType();
            test.Name = "newTest";

            // Act
            controller.Add(test);
            int id = controller.GetByName(test.Name);
            var result = controller.Get(id);

            //Assert
            Assert.AreEqual("newTest", result.Name);
        }

        [Test]
        public void Method4DeleteDeletesRecipeTypeById()
        {
            // Arrange
            RecipeTypeController controller = new RecipeTypeController();
            int id = controller.GetByName("newTest");

            // Act
            controller.Delete(id);
            var result = controller.Get(id);

            // Assert
            Assert.Null(result);
        }
    }
}