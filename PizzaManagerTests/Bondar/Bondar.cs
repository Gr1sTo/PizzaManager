namespace PizzaManagerTests.Test1
{
    public class UnitTest2
    {
       

        [Fact]

        // Тест для перевірки чи успішно було видалено піцу з меню
        public void RemovePizzaFromMenu_RemovesPizza_Successfully()
        {
            // Arrange
            PizzaOrderingSystem orderingSystem = new PizzaOrderingSystem();
            Pizza pizzaToRemove = new Pizza("Margherita", new List<Ingredient>());

            // Adding pizza to the menu
            orderingSystem.AddPizzaToMenu(pizzaToRemove);

            // Act
            orderingSystem.RemovePizzaFromMenu(pizzaToRemove);

            // Assert
            Assert.False(orderingSystem.GetAvailablePizzas().Contains(pizzaToRemove));
        }

        // Перевірка на додавання пійи без інградієнтів 
        [Fact]
        public void AddPizzaToOrder_WhenPizzaHasNoIngredients_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var pizzaWithoutIngredients = new Pizza("NoIngredientsPizza", new List<Ingredient>());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => orderingSystem.AddPizzaToOrder(pizzaWithoutIngredients));
        }

        //Перевірка чи не виконалось одне і те саме замовлення двічі
        public void AddPizzaToOrder_DuplicateOrder()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var pizza = new Pizza("Pepperoni", new List<Ingredient> { /* ingredients */ });

            // Act
            orderingSystem.AddPizzaToOrder(pizza);

            // Assert
            Assert.Throws<InvalidOperationException>(() => orderingSystem.AddPizzaToOrder(pizza));
        }



    }
}