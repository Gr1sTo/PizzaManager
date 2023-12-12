
namespace PizzaManagerTests.Test1 // Бондар Денис 
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


        [Fact]
        public void AddPizzaToOrder_WhenPizzaHasNoIngredients_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var pizzaWithoutIngredients = new Pizza("NoIngredientsPizza", new List<Ingredient>());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => orderingSystem.AddPizzaToOrder(pizzaWithoutIngredients));
        }







    }
}