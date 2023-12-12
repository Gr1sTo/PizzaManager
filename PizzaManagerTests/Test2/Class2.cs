
namespace PizzaManagerTests.Test1 // Бондар Денис 
{
    public class UnitTest2
    {
        [Fact]


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

    }
}