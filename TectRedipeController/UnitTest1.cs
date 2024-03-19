using Business;
using Data.Models;

namespace TectRedipeController
{
    //maria
    public class Tests
    {
        [Test]
        public void MethodGetAllReturnsAllRecipes()
        {
            // Arrange
            RecipeController controller = new RecipeController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void MethodAddAddsNewRecipe()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            Recipe recipe = new Recipe();
            recipe.Name = "NewRecipe";
            recipe.Kcal = 200;
            recipe.Rating = 5;
            recipe.TypeId = 2;
            recipe.Description = "newRecipeDescription";
            
            // Act
            controller.Add(recipe);
            int id = controller.GetByName(recipe.Name).Id;
            var result = controller.Get(id);

            //Assert
            Assert.AreEqual("NewRecipe", result.Name);
        }

        [Test]
        public void MethodDeleteDeletesRecipeById()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            int id = controller.GetByName("NewRecipe").Id;

            // Act
            controller.Delete(id);
            var result = controller.Get(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void MethodGetReturnsRecipeById()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            int id = 5;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void MethodUpdateUpdatesRecipeData()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            int id = controller.GetByName("NewRecipe").Id;
            Recipe recipe = controller.Get(id);
            recipe.Name = "UpdatedRecipe";
            recipe.Kcal = 220;
            recipe.Rating = 7;
            recipe.TypeId = 2;
            recipe.Description = "newRecipeDescription";

            // Act
            controller.Update(recipe);
            var result = controller.Get(id);

            // Assert
            Assert.AreEqual(11, result.Id);
        }

        [Test]
        public void MethodGetByNameReturnsRecipeByRecipeName()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            string name = "UpdatedRecipe";

            // Act
            var result = controller.GetByName(name);

            // Assert
            Assert.AreEqual(11, result.Id);
        }

        //gergana

        [Test]
        public void MethodSortByCaloriesSortsRecipesByCalories()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            Recipe recipe1 = new Recipe();
            recipe1.Name = "testRecipe1";
            recipe1.Kcal = 200;
            recipe1.Rating = 5;
            recipe1.TypeId = 2;
            recipe1.Description = "testRecipe1Description";
            Recipe recipe2 = new Recipe();
            recipe2.Name = "testRecipe2";
            recipe2.Kcal = 489;
            recipe2.Rating = 4;
            recipe2.TypeId = 5;
            recipe2.Description = "testRecipe2Description";
            Recipe recipe3 = new Recipe();
            recipe3.Name = "testRecipe3";
            recipe3.Kcal = 366;
            recipe3.Rating = 3;
            recipe3.TypeId = 4;
            recipe3.Description = "testRecipe3Description";

            // Act
            controller.Add(recipe1);
            controller.Add(recipe2);
            controller.Add(recipe3);
            var result = controller.SortByCalories();

            // Assert
            Assert.AreEqual("testRecipe1", result.First().Name);
            Assert.AreEqual("testRecipe2", result.Last().Name);
        }

        [Test]
        public void MethodTop5ByRatingReturns5HighestRatedRecipes()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            Recipe recipe4 = new Recipe();
            recipe4.Name = "testRecipe4";
            recipe4.Kcal = 200;
            recipe4.Rating = 7;
            recipe4.TypeId = 2;
            recipe4.Description = "testRecipe1Description";
            Recipe recipe5 = new Recipe();
            recipe5.Name = "testRecipe5";
            recipe5.Kcal = 489;
            recipe5.Rating = 8;
            recipe5.TypeId = 5;
            recipe5.Description = "testRecipe2Description";
            Recipe recipe6 = new Recipe();
            recipe6.Name = "testRecipe6";
            recipe6.Kcal = 366;
            recipe6.Rating = 9;
            recipe6.TypeId = 4;
            recipe6.Description = "testRecipe3Description";


            // Act
            controller.Add(recipe4);
            controller.Add(recipe5);
            controller.Add(recipe6);
            var result = controller.Top5ByRating();

            // Assert
            Assert.AreEqual("testRecipe6", result[0].Name);
            Assert.AreEqual("testRecipe5", result[1].Name);
            Assert.AreEqual("testRecipe4", result[2].Name);
            Assert.AreEqual("testRecipe1", result[3].Name);
            Assert.AreEqual("testRecipe2", result[4].Name);
        }
    }
}