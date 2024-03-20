using Business;
using Data.Models;

namespace TestRecipeController
{
    //maria
    public class Tests
    {
        [Test]
        public void Method1GetAllReturnsAllRecipes()
        {
            // Arrange
            RecipeController controller = new RecipeController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void Method2AddAddsNewRecipe()
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
        public void Method4CalculatePriceReturnsTotalPriceOfRecipe()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            ProductController pController = new ProductController();
            Recipe recipe = controller.GetByName("NewRecipe");

            // Act
            var result = controller.CalculatePrice(recipe);
            List<string> products = controller.GetProductsByRecipe(recipe.Name);
            pController.Delete(pController.GetByName(products[0]).Id);
            pController.Delete(pController.GetByName(products[1]).Id);

            // Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Method3GetProductsByRecipeReturnsAllProductsInGivenRecipe()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            ProductController pController = new ProductController();
            Recipe recipe = controller.GetByName("NewRecipe");
            Product product1 = new Product();
            product1.Name = "testProduct";
            product1.Price = 1.5;
            product1.TypeId = 2;
            Product product2 = new Product();
            product2.Name = "testProduct2";
            product2.Price = 2.5;
            product2.TypeId = 3;

            // Act
            pController.Add(product1);
            pController.Add(product2);
            Product_Recipe pr = new Product_Recipe();
            pr.RecipeId = controller.GetByName(recipe.Name).Id;
            pr.ProductId = pController.GetByName(product1.Name).Id;
            controller.AddProductRecipe(pr);
            Product_Recipe pr2 = new Product_Recipe();
            pr2.RecipeId = controller.GetByName(recipe.Name).Id;
            pr2.ProductId = pController.GetByName(product2.Name).Id;
            controller.AddProductRecipe(pr2);
            var result = controller.GetProductsByRecipe("NewRecipe");
            
            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Method5UpdateUpdatesRecipeData()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            int id = controller.GetByName("NewRecipe").Id;
            Recipe recipe = controller.Get(id);
            recipe.Name = "UpdatedRecipe";

            // Act
            controller.Update(recipe);
            var result = controller.Get(id);

            // Assert
            Assert.AreEqual("UpdatedRecipe", result.Name);
        }

        [Test]
        public void Method6DeleteDeletesRecipeById()
        {
            // Arrange
            RecipeController controller = new RecipeController();
            int id = controller.GetByName("UpdatedRecipe").Id;

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
            int id = 2;

            // Act
            var result = controller.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void MethodSortByCaloriesSortsRecipesByCalories()
        {
            // Arrange
            List<Recipe> testRecipes = new List<Recipe>();
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
            testRecipes.Add(recipe1);
            testRecipes.Add(recipe2);
            testRecipes.Add(recipe3);
            var result = controller.SortByCalories(testRecipes);

            // Assert
            Assert.AreEqual("testRecipe1", result.First().Name);
            Assert.AreEqual("testRecipe2", result.Last().Name);
        }

        //gergana

        [Test]
        public void MethodTop5ByRatingReturns5HighestRatedRecipes()
        {
            // Arrange
            List<Recipe> testRecipes = new List<Recipe>();
            RecipeController controller = new RecipeController();
            Recipe recipe1 = new Recipe();
            recipe1.Name = "testRecipe1";
            recipe1.Kcal = 200;
            recipe1.Rating = 4;
            recipe1.TypeId = 2;
            recipe1.Description = "testRecipe1Description";
            Recipe recipe2 = new Recipe();
            recipe2.Name = "testRecipe2";
            recipe2.Kcal = 200;
            recipe2.Rating = 7;
            recipe2.TypeId = 2;
            recipe2.Description = "testRecipe2Description";
            Recipe recipe3 = new Recipe();
            recipe3.Name = "testRecipe3";
            recipe3.Kcal = 366;
            recipe3.Rating = 9;
            recipe3.TypeId = 4;
            recipe3.Description = "testRecipe3Description";
            Recipe recipe4 = new Recipe();
            recipe4.Name = "testRecipe4";
            recipe4.Kcal = 200;
            recipe4.Rating = 2;
            recipe4.TypeId = 2;
            recipe4.Description = "testRecipe4Description";
            Recipe recipe5 = new Recipe();
            recipe5.Name = "testRecipe5";
            recipe5.Kcal = 489;
            recipe5.Rating = 8;
            recipe5.TypeId = 5;
            recipe5.Description = "testRecipe5Description";

            // Act
            testRecipes.Add(recipe1);
            testRecipes.Add(recipe2);
            testRecipes.Add(recipe3);
            testRecipes.Add(recipe4);
            testRecipes.Add(recipe5);
            var result = controller.Top5ByRating(testRecipes);

            // Assert
            Assert.AreEqual("testRecipe3", result[0].Name);
            Assert.AreEqual("testRecipe5", result[1].Name);
            Assert.AreEqual("testRecipe2", result[2].Name);
            Assert.AreEqual("testRecipe1", result[3].Name);
            Assert.AreEqual("testRecipe4", result[4].Name);
        }

        //maria
        [Test]
        public void MethodGetAllByTypeReturnsAllRecipesFromGivenType()
        {
            // Arrange
            List<Recipe> testRecipes = new List<Recipe>();
            RecipeController controller = new RecipeController();
            Recipe recipe1 = new Recipe();
            recipe1.Name = "testRecipe1";
            recipe1.Kcal = 200;
            recipe1.Rating = 4;
            recipe1.TypeId = 2;
            recipe1.Description = "testRecipe1Description";
            Recipe recipe2 = new Recipe();
            recipe2.Name = "testRecipe2";
            recipe2.Kcal = 200;
            recipe2.Rating = 7;
            recipe2.TypeId = 2;
            recipe2.Description = "testRecipe2Description";
            Recipe recipe3 = new Recipe();
            recipe3.Name = "testRecipe3";
            recipe3.Kcal = 366;
            recipe3.Rating = 9;
            recipe3.TypeId = 4;
            recipe3.Description = "testRecipe3Description";
            Recipe recipe4 = new Recipe();
            recipe4.Name = "testRecipe4";
            recipe4.Kcal = 200;
            recipe4.Rating = 2;
            recipe4.TypeId = 2;
            recipe4.Description = "testRecipe4Description";
            Recipe recipe5 = new Recipe();
            recipe5.Name = "testRecipe5";
            recipe5.Kcal = 489;
            recipe5.Rating = 8;
            recipe5.TypeId = 5;
            recipe5.Description = "testRecipe5Description";
            string type = "салата";

            // Act
            testRecipes.Add(recipe1);
            testRecipes.Add(recipe2);
            testRecipes.Add(recipe3);
            testRecipes.Add(recipe4);
            testRecipes.Add(recipe5);
            var result = controller.GetAllByType(testRecipes,type);

            // Assert
            Assert.AreEqual(3, result.Count);

        }
    }
}