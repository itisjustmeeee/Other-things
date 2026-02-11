using System;
using System.Collections.Generic;

public class OrderItem
{
    public Dish Dish { get; set; }
    public int Quantity { get; set; }

    public OrderItem(Dish dish, int quantity = 1)
    {
        Dish = dish;
        Quantity = quantity;
    }

    public double TotalPrice => Dish.Price * Quantity;
}

public class Order
{
    public int Id { get; private set; }
    public int TableId { get; set; }
    public List<OrderItem> Items { get; private set; }
    public string Comment { get; set; }
    public string TimeCreated { get; private set; }
    public int WaiterId { get; set; }
    public string TimeClosed { get; private set; }
    public double TotalAmount { get; private set; }

    private static int nextId = 1;
    private bool isClosed = false;

    public Order(int tableId, int waiterId, string comment = "")
    {
        Id = nextId++;
        TableId = tableId;
        WaiterId = waiterId;
        Comment = comment;
        Items = new List<OrderItem>();
        TimeCreated = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
    }

    public void AddDish(Dish dish, int quantity = 1)
    {
        if (isClosed) { Console.WriteLine("Заказ закрыт!"); return; }

        var existing = Items.Find(i => i.Dish.Id == dish.Id);
        if (existing != null)
            existing.Quantity += quantity;
        else
            Items.Add(new OrderItem(dish, quantity));
    }

    public void CloseOrder()
    {
        if (isClosed) return;
        isClosed = true;
        TimeClosed = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        TotalAmount = 0;
        foreach (var item in Items)
            TotalAmount += item.TotalPrice;
    }

    public void PrintCheck()
    {
        if (!isClosed)
        {
            Console.WriteLine("Заказ ещё не закрыт!");
            return;
        }

        Console.WriteLine("═" + "═".PadRight(48, '═') + "═");
        Console.WriteLine($"       РЕСТОРАН «УЮТ»");
        Console.WriteLine($"Столик: {TableId}     Официант: {WaiterId}");
        Console.WriteLine($"Период обслуживания: {TimeCreated} — {TimeClosed}");
        Console.WriteLine("─".PadRight(50, '─'));

        var byCategory = new Dictionary<DishCategory, List<OrderItem>>();
        foreach (var item in Items)
        {
            if (!byCategory.ContainsKey(item.Dish.Category))
                byCategory[item.Dish.Category] = new List<OrderItem>();
            byCategory[item.Dish.Category].Add(item);
        }

        double grandTotal = 0;
        foreach (var cat in byCategory)
        {
            Console.WriteLine($"{cat.Key}:");
            double catTotal = 0;
            foreach (var item in cat.Value)
            {
                double lineTotal = item.Quantity * item.Dish.Price;
                catTotal += lineTotal;
                grandTotal += lineTotal;
                Console.WriteLine($"  {item.Dish.Name} x{item.Quantity} * {item.Dish.Price:F2} = {lineTotal:F2} Rub");
            }
            Console.WriteLine($"  Подытог {cat.Key}: {catTotal:F2} Rub\n");
        }

        Console.WriteLine("─".PadRight(50, '─'));
        Console.WriteLine($"ИТОГ СЧЕТА: ".PadRight(35) + $"{grandTotal:F2} Rub");
        Console.WriteLine("═" + "═".PadRight(48, '═') + "═\n");
    }

    public override string ToString()
    {
        return $"Заказ #{Id} | Стол {TableId} | Официант {WaiterId} | Блюд: {Items.Count} | {(isClosed ? "Закрыт" : "Открыт")}";
    }
}