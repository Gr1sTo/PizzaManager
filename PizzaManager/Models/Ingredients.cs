﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManager.Models
{
    public class Ingredient
    {
        public string Name { get; }
        public decimal Price { get; }

        public Ingredient (string name, decimal price)//перевірка на null + перев ціни >= 0
        {
            Name = name;
            Price = price;
        }
    }
}