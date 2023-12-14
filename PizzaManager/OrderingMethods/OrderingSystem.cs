using PizzaManager.Models;

namespace PizzaManager.OrderingMethods
{
    public class PizzaOrderingSystem
    {
        private List<Ingredient> availableIngredients;
        private List<Pizza> availablePizzas;
        private List<Pizza> orderedPizzas;

        public PizzaOrderingSystem()
        {
            availableIngredients = new List<Ingredient>();
            availablePizzas = new List<Pizza>();
            orderedPizzas = new List<Pizza>();
        }


        public List<(string, decimal)> GetAvailableIngredients()
        {
            return availableIngredients.Select(ingredient => (ingredient.Name, ingredient.Price)).ToList();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient), "Ingredient cannot be null");
            }

            availableIngredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)//якщо не має інгрид то ніч не змін 2. перевірити чи є в списку
        {
            availableIngredients.Remove(ingredient);
        }

        public List<Pizza> GetAvailablePizzas()
        {
            return availablePizzas;
        }
        public void AddPizzaToMenu(Pizza pizza)
        {
            availablePizzas.Add(pizza);
        }

        public object GetOrderedPizzas()
        {
            throw new NotImplementedException();
        }

        public void RemovePizzaFromMenu(Pizza pizza)
        {
            availablePizzas.Remove(pizza);
        }


        public void AddPizzaToOrder(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza), "Pizza cannot be null");
            }

            if (pizza.Ingredients == null || !pizza.Ingredients.Any())
            {
                throw new InvalidOperationException("Cannot add a pizza with no ingredients to the order");
            }

            orderedPizzas.Add(pizza);
        }

        public void RemovePizzaFromOrder(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza), "Pizza cannot be null");
            }

            orderedPizzas.Remove(pizza);
        }

        public List<Pizza> GetPopularPizzas()
        {
            return orderedPizzas.GroupBy(pizza => pizza.Name)
                                .OrderByDescending(group => group.Count())
                                .SelectMany(group => group)
                                .Distinct()
                                .ToList();
        }

    }
}