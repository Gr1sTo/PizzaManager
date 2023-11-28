namespace PizzaManagerTests.Test1
{
    public class UnitTest1
    {

        // Перевіряє, що метод AddIngredient дійсно додає інгредієнт до списку доступних інгредієнтів.
        [Fact]
        public void AddIngredient_ShouldAddIngredientToAvailableIngredients()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var ingredient = new Ingredient ("Cheese", 1.50m );

            // Act
            orderingSystem.AddIngredient(ingredient);

            // Assert
            Assert.True(orderingSystem.GetAvailableIngredients().Any(i => i.Item1 == "Cheese"));
        }

        // Перевіряє, що метод RemoveIngredient видаляє інгредієнт зі списку доступних інгредієнтів.
        [Fact]
        public void RemoveIngredient_ShouldRemoveIngredientFromAvailableIngredients()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var ingredient = new Ingredient("Tomato", 0.75m);
            orderingSystem.AddIngredient(ingredient);

            // Act
            orderingSystem.RemoveIngredient(ingredient);

            // Assert
            Assert.False(orderingSystem.GetAvailableIngredients().Any(i => i.Item1 == "Tomato"));
        }

        // Цей тест перевіряє, що система нараховує кількість інгредієнтів, які були додані, незалежно від того, чи додаються вони кілька разів.
        [Fact]
        public void AddIngredient_MultipleTimes_ShouldIncreaseAvailableIngredientsAccordingly()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var cheese = new Ingredient("Cheese", 1.50m);
            var tomato = new Ingredient("Tomato", 0.75m);

            // Act
            orderingSystem.AddIngredient(cheese);
            orderingSystem.AddIngredient(tomato);
            orderingSystem.AddIngredient(cheese);

            // Assert
            int expectedCount = 3; // Очікувана кількість інгредієнтів після додавання
            Assert.Equal(expectedCount, orderingSystem.GetAvailableIngredients().Count);
        }

        // 
        [Fact]
        public void AddIngredient_ShouldNotAllowDuplicateIngredients()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var cheese = new Ingredient("Cheese", 1.50m);
            var duplicateCheese = new Ingredient("Cheese", 1.50m); // Той самий інгредієнт

            // Act
            orderingSystem.AddIngredient(cheese);
            orderingSystem.AddIngredient(duplicateCheese);

            // Assert
            int expectedCount = 1; // Очікуємо тільки один унікальний інгредієнт
            Assert.Equal(expectedCount, orderingSystem.GetAvailableIngredients().Count);
        }
    }
}