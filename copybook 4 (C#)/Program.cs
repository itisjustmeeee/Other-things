using System;
using System.Collections.Generic;

class Restaurant
{
    static List<Dish> menu = new List<Dish>();
    static List<Order> orders = new List<Order>();

    static void Main()
    {
        InitializeMenu();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== СИСТЕМА ЗАКАЗОВ РЕСТОРАНА ===");
            Console.WriteLine("1. Показать меню");
            Console.WriteLine("2. Создать заказ");
            Console.WriteLine("3. Добавить блюдо в заказ");
            Console.WriteLine("4. Закрыть заказ и выдать чек");
            Console.WriteLine("5. Все заказы");
            Console.WriteLine("6. Общая выручка (закрытые заказы)");
            Console.WriteLine("7. Заказы официанта");
            Console.WriteLine("8. Статистика по блюдам");
            Console.WriteLine("0. Выход");
            Console.Write("-> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": PrintMenuByCategory(); break;
                case "2": CreateOrder(); break;
                case "3": AddDishToOrder(); break;
                case "4": CloseAndPrintCheck(); break;
                case "5": ListAllOrders(); break;
                case "6": TotalRevenue(); break;
                case "7": WaiterOrders(); break;
                case "8": DishStatistics(); break;
                case "0": return;
            }
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    static void InitializeMenu()
    {
        menu.Add(new Dish("Цезарь с курицей", "салат, курица, сухари, пармезан", "250/50", 420, DishCategory.Салаты, 12, "халяль"));
        menu.Add(new Dish("Борщ", "свекла, капуста, мясо, сметана", "300/50", 320, DishCategory.Супы, 20));
        menu.Add(new Dish("Стейк рибай", "говядина, специи", "300", 1350, DishCategory.ГорячиеБлюда, 25, "халяль"));
        menu.Add(new Dish("Кола", "газировка", "500", 150, DishCategory.Напитки, 1));
        menu.Add(new Dish("Тирамису", "маскарпоне, савоярди, кофе", "150", 380, DishCategory.Десерт, 5, "вегетарианское"));
    }

    static void PrintMenuByCategory()
    {
        var grouped = new Dictionary<DishCategory, List<Dish>>();
        foreach (var dish in menu)
        {
            if (!grouped.ContainsKey(dish.Category))
                grouped[dish.Category] = new List<Dish>();
            grouped[dish.Category].Add(dish);
        }

        foreach (var cat in grouped)
        {
            Console.WriteLine($"\n=== {cat.Key} ===");
            foreach (var dish in cat.Value)
                dish.Print();
        }
    }

    static void CreateOrder()
    {
        Console.Write("Номер столика: ");
        int table = int.Parse(Console.ReadLine());
        Console.Write("ID официанта: ");
        int waiter = int.Parse(Console.ReadLine());
        Console.Write("Комментарий (или Enter): ");
        string comment = Console.ReadLine() ?? "";

        Order order = new Order(table, waiter, comment);
        orders.Add(order);
        Console.WriteLine($"Создан заказ #{order.Id}");
    }

    static void AddDishToOrder()
    {
        Console.Write("ID заказа: ");
        int id = int.Parse(Console.ReadLine());
        Order order = orders.Find(o => o.Id == id);
        if (order == null) { Console.WriteLine("Заказ не найден"); return; }

        Console.WriteLine("Доступные блюда:");
        for (int i = 0; i < menu.Count; i++)
            Console.WriteLine($"{menu[i].Id}. {menu[i]}");

        Console.Write("ID блюда: ");
        int dishId = int.Parse(Console.ReadLine());
        Console.Write("Количество: ");
        int qty = int.Parse(Console.ReadLine());

        Dish dish = menu.Find(d => d.Id == dishId);
        if (dish != null)
            order.AddDish(dish, qty);
    }

    static void CloseAndPrintCheck()
    {
        Console.Write("ID заказа для закрытия: ");
        int id = int.Parse(Console.ReadLine());
        Order order = orders.Find(o => o.Id == id);
        if (order != null)
        {
            order.CloseOrder();
            order.PrintCheck();
        }
    }

    static void ListAllOrders() => orders.ForEach(o => Console.WriteLine(o));

    static void TotalRevenue()
    {
        double total = 0;
        foreach (var o in orders)
            if (!string.IsNullOrEmpty(o.TimeClosed))
                total += o.TotalAmount;
        Console.WriteLine($"Общая выручка: {total:F2} Rub");
    }

    static void WaiterOrders()
    {
        Console.Write("ID официанта: ");
        int waiter = int.Parse(Console.ReadLine());
        double sum = 0;
        int count = 0;
        foreach (var o in orders)
            if (o.WaiterId == waiter && !string.IsNullOrEmpty(o.TimeClosed))
            {
                Console.WriteLine(o);
                sum += o.TotalAmount;
                count++;
            }
        Console.WriteLine($"Итого: {count} заказов, {sum:F2} Rub");
    }

    static void DishStatistics()
    {
        var stats = new Dictionary<string, int>();
        foreach (var order in orders)
            if (!string.IsNullOrEmpty(order.TimeClosed))
                foreach (var item in order.Items)
                {
                    if (stats.ContainsKey(item.Dish.Name))
                        stats[item.Dish.Name] += item.Quantity;
                    else
                        stats[item.Dish.Name] = item.Quantity;
                }

        Console.WriteLine("Статистика по блюдам:");
        foreach (var s in stats)
            Console.WriteLine($"{s.Key}: {s.Value} порций");
    }
}