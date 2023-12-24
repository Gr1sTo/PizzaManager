namespace PizzaManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaOrderingSystem = new PizzaOrderingSystem();
            bool exit = false;
            InitializePizzaOrderingSystem(pizzaOrderingSystem);

            while (!exit)
            {
                Console.WriteLine("Виберіть опцію:");
                Console.WriteLine("1: Переглянути доступні піци");
                Console.WriteLine("2: Переглянути доступні інгредієнти");
                Console.WriteLine("3: Додати піццу до замовлення");
                Console.WriteLine("4: Переглянути замовлені піци");
                Console.WriteLine("0: Вийти");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAvailablePizzas(pizzaOrderingSystem);
                        break;
                    case "2":
                        ShowAvailableIngredients(pizzaOrderingSystem);
                        break;
                    case "3":
                        AddPizzaToOrder(pizzaOrderingSystem);
                        break;
                    case "4":
                        ShowOrderedPizzas(pizzaOrderingSystem);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір. Спробуйте знову.");
                        break;
                }
            }
        }

        private static void ShowAvailablePizzas(PizzaOrderingSystem system)
        {
            var availablePizzas = system.GetAvailablePizzas();

            if (availablePizzas.Count == 0)
            {
                Console.WriteLine("Наразі немає доступних піц.");
            }
            else
            {
                Console.WriteLine("Доступні піци:");
                foreach (var pizza in availablePizzas)
                {
                    Console.WriteLine($"Назва піци: {pizza.Name}");
                    Console.Write("Інгредієнти: ");
                    foreach (var ingredient in pizza.Ingredients)
                    {
                        Console.Write($"{ingredient.Name} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void ShowAvailableIngredients(PizzaOrderingSystem system)
        {
            var ingredients = system.GetAvailableIngredients();

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Наразі немає доступних інгредієнтів.");
                return;
            }
            else
            {
                Console.WriteLine("Доступні інгредієнти:");
                foreach (var ingredient in ingredients)
                {
                    Console.WriteLine($"{ingredient.Item1} - {ingredient.Item2:C}");
                }
            }
        }

        private static void AddPizzaToOrder(PizzaOrderingSystem system)
        {
            Console.WriteLine("Додавання піци до замовлення:");
            var availablePizzas = system.GetAvailablePizzas();

            if (availablePizzas.Count == 0)
            {
                Console.WriteLine("Наразі немає доступних піц у меню.");
                return;
            }

            Console.WriteLine("Доступні піци:");
            for (int i = 0; i < availablePizzas.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {availablePizzas[i].Name}");
            }

            Console.WriteLine("Введіть номер піци, яку бажаєте додати до замовлення, або введіть 0 для повернення до головного меню:");
            int pizzaChoice;
            if (!int.TryParse(Console.ReadLine(), out pizzaChoice) || pizzaChoice < 0 || pizzaChoice > availablePizzas.Count)
            {
                Console.WriteLine("Неправильний вибір. Спробуйте знову.");
                return;
            }

            if (pizzaChoice == 0) return;

            try
            {
                system.AddPizzaToOrder(availablePizzas[pizzaChoice - 1]);
                Console.WriteLine($"Піца '{availablePizzas[pizzaChoice - 1].Name}' успішно додана до замовлення.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні піци до замовлення: {ex.Message}");
            }
        }

        private static void ShowOrderedPizzas(PizzaOrderingSystem system)
        {
            var orderedPizzas = system.GetOrderedPizzas();

            if (orderedPizzas.Any())
            {
                Console.WriteLine("Замовлені піци:");
                foreach (var pizza in orderedPizzas)
                {
                    Console.Write($"Назва піци: {pizza.Name}, Інгредієнти: ");

                    foreach (var ingredient in pizza.Ingredients)
                    {
                        Console.Write($"{ingredient.Name} ");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Наразі немає замовлених піц.");
            }
        }

        public static void InitializePizzaOrderingSystem(PizzaOrderingSystem system)
        {
            // Інгредієнти для Маргарити
            var ingredientsForMargherita = new List<Ingredient>
            {
                new Ingredient("Томатний соус", 0.5m),
                new Ingredient("Моцарела", 1.0m),
                new Ingredient("Базилік", 0.2m)
            };
            var margheritaPizza = new Pizza("Маргарита", ingredientsForMargherita);

            // Інгредієнти для Пеппероні
            var ingredientsForPepperoni = new List<Ingredient>
            {
                new Ingredient("Томатний соус", 0.5m),
                new Ingredient("Моцарела", 1.0m),
                new Ingredient("Пеппероні", 1.5m)
            };
            var pepperoniPizza = new Pizza("Пеппероні", ingredientsForPepperoni);

            // Інгредієнти для Гавайської
            var ingredientsForHawaiian = new List<Ingredient>
            {
                new Ingredient("Томатний соус", 0.5m),
                new Ingredient("Моцарела", 1.0m),
                new Ingredient("Шинка", 1.2m),
                new Ingredient("Ананас", 0.8m)
            };
            var hawaiianPizza = new Pizza("Гавайська", ingredientsForHawaiian);

            system.AddPizzaToMenu(margheritaPizza);
            system.AddPizzaToMenu(pepperoniPizza);
            system.AddPizzaToMenu(hawaiianPizza);
            
            system.AddIngredient(new Ingredient("Томатний соус", 0.5m));
            system.AddIngredient(new Ingredient("Моцарела", 1.0m));
            system.AddIngredient(new Ingredient("Шинка", 1.2m));
            system.AddIngredient(new Ingredient("Ананас", 0.8m));
            system.AddIngredient(new Ingredient("Пеппероні", 1.5m));
            system.AddIngredient(new Ingredient("Базилік", 0.2m));
        }
    }
}