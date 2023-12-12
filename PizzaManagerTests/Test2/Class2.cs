
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
        public void GetPopularPizzas_ShouldReturnPizzasInCorrectOrder()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var pizza1 = new Pizza("Pizza1", new List<Ingredient>());
            var pizza2 = new Pizza("Pizza2", new List<Ingredient>());
            var pizza3 = new Pizza("Pizza3", new List<Ingredient>());

            // Add pizzas to order multiple times
            orderingSystem.AddPizzaToOrder(pizza1);
            orderingSystem.AddPizzaToOrder(pizza2);
            orderingSystem.AddPizzaToOrder(pizza2);
            orderingSystem.AddPizzaToOrder(pizza3);
            orderingSystem.AddPizzaToOrder(pizza3);
            orderingSystem.AddPizzaToOrder(pizza3);

            // Act
            var popularPizzas = orderingSystem.GetPopularPizzas();

            // Assert
            Assert.Equal("Pizza3", popularPizzas[0].Name);
            Assert.Equal("Pizza2", popularPizzas[1].Name);
            Assert.Equal("Pizza1", popularPizzas[2].Name);
        }




    }
}