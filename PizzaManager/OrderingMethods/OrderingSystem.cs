﻿using PizzaManager.Models;

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

        //=====================Ryzhenko====================================
        public List<(string, decimal)> GetAvailableIngredients()
        {
            return availableIngredients.Select(ingredient => (ingredient.Name, ingredient.Price)).ToList();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            availableIngredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            availableIngredients.Remove(ingredient);
        }
        //=====================Ryzhenko====================================

        public void AddPizzaToMenu(Pizza pizza)
        {
            availablePizzas.Add(pizza);
        }

        public void RemovePizzaFromMenu(Pizza pizza)
        {
            availablePizzas.Remove(pizza);
        }

        public void AddPizzaToOrder(Pizza pizza)
        {
            orderedPizzas.Add(pizza);
        }

        public void RemovePizzaFromOrder(Pizza pizza)
        {
            orderedPizzas.Remove(pizza);
        }

        public List<Pizza> GetPopularPizzas()
        {
            return orderedPizzas.GroupBy(pizza => pizza.Name)
                                .OrderByDescending(group => group.Count())
                                .Select(group => group.First())
                                .ToList();
        }
    }
}