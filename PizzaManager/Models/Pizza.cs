using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManager.Models
{
    public class Pizza
    {
        public string Name { get; }
        public List<Ingredient> Ingredients { get; }

        public Pizza(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}