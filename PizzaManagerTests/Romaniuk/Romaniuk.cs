
using System.Collections.Generic; // Added for List<T>

namespace PizzaManagerTests.Test1
{
 
        public class UnitTest4
        {
        [Fact]
        public void AddPizzaToMenu_ShouldAddPizzaToAvailablePizzas()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var pizza = new Pizza("Pepperoni", new List<Ingredient>
            {
                new Ingredient("Pepperoni", 2.00m),
                new Ingredient("Cheese", 1.50m)
                // Додайте інші інгредієнти, які можливо потрібні для вашого тесту
            });

            // Act
            orderingSystem.AddPizzaToMenu(pizza);

            // Assert
            var availablePizzas = orderingSystem.GetAvailablePizzas();

            Assert.Contains(pizza, availablePizzas);
            
        }

       
        [Fact]
        public void GetOrderedPizzas_ShouldReturnListOfOrderedPizzas()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var ingredientList = new List<Ingredient> { new Ingredient("Cheese", 1.50m), new Ingredient("Tomato", 0.50m) };
            var pizza = new Pizza("Margherita", ingredientList);

            orderingSystem.AddPizzaToOrder(pizza);

            // Act
            var orderedPizzas = orderingSystem.GetOrderedPizzas() as List<Pizza>;

            // Assert
            Assert.NotNull(orderedPizzas);
            Assert.Single(orderedPizzas);
            Assert.Equal("Margherita", orderedPizzas[0].Name);
            Assert.Equal(ingredientList, orderedPizzas[0].Ingredients);
        }

        [Fact]
        public void RemovePizzaFromMenu_ShouldRemovePizzaFromAvailablePizzas()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var cheese = new Ingredient("Cheese", 1.50m);
            var tomato = new Ingredient("Tomato", 0.75m);
            var pizzaToRemove = new Pizza("Margherita", new List<Ingredient> { cheese, tomato });

            orderingSystem.AddIngredient(cheese);
            orderingSystem.AddIngredient(tomato);
            orderingSystem.AddPizzaToMenu(pizzaToRemove);

            // Act
            orderingSystem.RemovePizzaFromMenu(pizzaToRemove);

            // Assert
            var availablePizzas = orderingSystem.GetAvailablePizzas();
            Assert.DoesNotContain(pizzaToRemove, availablePizzas);
        }

    }

    
}
