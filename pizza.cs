    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Shop
    {
        public static void Main()
        {
            List<OrderHistory> history = new List<OrderHistory>();

            while (true)
            {
                var orderInfo = Order.OrderInfo();
                if (orderInfo == null)
                {
                    break;
                }
                (string name, int amount, string size, DateTime date) = orderInfo.Value;
                Pizza pizza;

                if (name == "margarita")
                {
                    pizza = new Margarita(name, amount, size);
                }
                else
                {
                    pizza = new BossPizza(name, amount, size);
                }

                Console.WriteLine(pizza.CurrentOrder());

                history.Add(new OrderHistory(name, amount, size, date));
            }

            OrderHistory(history);
        }

        public static void OrderHistory(List<OrderHistory> orderHistoryList)
        {
            var groupedOrders = orderHistoryList
                .GroupBy(o => o.Date.Date)
                .OrderBy(g => g.Key);

            foreach (var group in groupedOrders)
            {
                Console.WriteLine($"\nOrders for {group.Key:dd.MM.yyyy}:");

                int totalMargarita = group.Where(o => o.PizzaName == "margarita").Sum(o => o.Amount);
                int totalBossPizza = group.Where(o => o.PizzaName == "boss' pizza").Sum(o => o.Amount);
                int totalPizzas = group.Sum(o => o.Amount);

                int totalRevenue = group.Sum(o =>
                {
                    int price = o.Size switch
                    {
                        "small" => o.PizzaName == "margarita" ? 5 : 20,
                        "medium" => o.PizzaName == "margarita" ? 10 : 25,
                        _ => o.PizzaName == "margarita" ? 15 : 30
                    };
                    return o.Amount * price;
                });

                Console.WriteLine($"Total Margaritas: {totalMargarita}");
                Console.WriteLine($"Total Boss Pizzas: {totalBossPizza}");
                Console.WriteLine($"Total Pizzas: {totalPizzas}");
                Console.WriteLine($"Total Revenue: ${totalRevenue}");
            }
        }
    }

    class Order
    {
        public string PizzaName { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public DateTime Date { get; set; }

        public Order(string pizzaName, int amount, string size, DateTime date)
        {
            PizzaName = pizzaName;
            Amount = amount;
            Size = size;
            Date = date;
        }

        public static (string, int, string, DateTime)? OrderInfo()
        {
            List<string> pizzaMenu = new List<string> { "margarita", "boss' pizza" };
            List<string> pizzaSizes = new List<string> { "small", "medium", "large" };

            Console.WriteLine("Enter your desired pizza (pizza name, amount, size, date)");
            string order = Console.ReadLine();
            if (order.ToLower() == "end")
            {
                return null;
            }
            string[] orderInfo = order.Split(',');

            if (orderInfo.Length != 4)
            {
                Console.WriteLine("Please follow the given format");
                return OrderInfo();
            }

            string pizzaType = orderInfo[0].ToLower().Trim();
            int pizzaAmount = Convert.ToInt32(orderInfo[1].Trim());
            string pizzaSize = orderInfo[2].ToLower().Trim();

            DateTime orderDate;
            if (!DateTime.TryParseExact(orderInfo[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out orderDate))
            {
                Console.WriteLine("Invalid date format! Please use dd.MM.yyyy");
                return OrderInfo();
            }

            if (!pizzaMenu.Contains(pizzaType))
            {
                Console.WriteLine("There is no such pizza on the menu, please choose from the following: ");
                Console.WriteLine(string.Join(", ", pizzaMenu));
                return OrderInfo();
            }

            if (pizzaAmount < 0)
            {
                Console.WriteLine("You cannot use a negative number for pizzas' amount");
                return OrderInfo();
            }

            if (!pizzaSizes.Contains(pizzaSize))
            {
                Console.WriteLine("This size is not available, please choose from the following: ");
                Console.WriteLine(string.Join(", ", pizzaSizes));
                return OrderInfo();
            }

            return (pizzaType, pizzaAmount, pizzaSize, orderDate);
        }
    }

    class OrderHistory : Order
    {
        public OrderHistory(string pizzaType, int amount, string size, DateTime date)
            : base(pizzaType, amount, size, date) { }
    }

    class Pizza
    {
        public string Name { get; }
        public int Amount { get; }
        public string Size { get; }
        public int Price { get; protected set; }

        public Pizza(string name, int amount, string size)
        {
            Name = name;
            Amount = amount;
            Size = size;
        }

        public virtual string CurrentOrder()
        {
            return $"{Name} preparing...\n";
        }
    }

    class Margarita : Pizza
    {
        public Margarita(string name, int amount, string size) : base(name, amount, size)
        {
            Price = size switch
            {
                "small" => 5,
                "medium" => 10,
                _ => 15
            };
        }

        public override string CurrentOrder()
        {
            int grams = Price switch
            {
                5 => 300,
                10 => 500,
                _ => 800
            };
            int totalGrams = grams * Amount;
            CultureInfo culture = new CultureInfo("en-US");
            int total = Price * Amount;
            return base.CurrentOrder() + $"\nPizza dough {Amount} * {grams} = {totalGrams}\nTomatoes {Amount} * 1 = {Amount}\nTotal: {total.ToString("C", culture)}";
        }
    }

class BossPizza : Pizza
{
    public BossPizza(string name, int amount, string size) : base(name, amount, size)
    {
        Price = size switch
        {
            "small" => 20,
            "medium" => 25,
            _ => 30
        };
    }

    public override string CurrentOrder()
    {
        int grams = Size switch
        {
            "small" => 300,
            "medium" => 500,
            _ => 800
        };
        int totalGrams = grams * Amount;
        CultureInfo culture = new CultureInfo("en-US");
        int total = Price * Amount;
        int ham = Amount * 100;
        return base.CurrentOrder() + $"\nPizza dough {Amount} * {grams} = {totalGrams}\nHam {Amount} * 100 = {ham}gr\nTotal: {total.ToString("C", culture)}";
    }
}
