
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

        /*[Fact]
        public void GetOrderedPizzas_ShouldReturnListOfPizzas()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            var cheese = new Ingredient("Cheese", 1.50m);
            var tomato = new Ingredient("Tomato", 0.75m);
            var pizza1 = new Pizza("Margherita", new List<Ingredient> { cheese, tomato });
            var pizza2 = new Pizza("Pepperoni", new List<Ingredient> { cheese });

            orderingSystem.AddIngredient(cheese);
            orderingSystem.AddIngredient(tomato);
            orderingSystem.AddPizzaToOrder(pizza1);
            orderingSystem.AddPizzaToOrder(pizza2);

            // Act
            var orderedPizzas = orderingSystem.GetOrderedPizzas();

            // Assert
            Assert.IsType<List<Pizza>>(orderedPizzas);
            Assert.Equal(2, orderedPizzas.Count);
            // перевірити чи серед замовлених піц є ті, які ви додали
            Assert.Contains(pizza1, orderedPizzas);
            Assert.Contains(pizza2, orderedPizzas);
        }

        */
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
    }
    
}
