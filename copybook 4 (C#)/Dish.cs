using System;

public enum DishCategory
{
    Напитки, Салаты, ХолодныеЗакуски, ГорячиеЗакуски,
    Супы, ГорячиеБлюда, Десерт, Гарниры
}

public class Dish
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Weight { get; set; }        // например "250/50/100"
    public double Price { get; set; }
    public DishCategory Category { get; set; }
    public int CookingTimeMinutes { get; set; }
    public string[] Tags { get; set; }        // острое, веган, халяль и т.д.

    private static int nextId = 1;

    public Dish(string name, string ingredients, string weight, double price, DishCategory category, int cookingTime, params string[] tags)
    {
        Id = nextId++;
        Name = name;
        Ingredients = ingredients;
        Weight = weight;
        Price = price;
        Category = category;
        CookingTimeMinutes = cookingTime;
        Tags = tags.Length > 0 ? tags : new string[0];
    }

    public void Edit(in string name, in string ingredients, in string weight, double price, DishCategory category, int cookingTime, params string[] tags)
    {
        Name = name;
        Ingredients = ingredients;
        Weight = weight;
        Price = price;
        Category = category;
        CookingTimeMinutes = cookingTime;
        Tags = tags.Length > 0 ? tags : new string[0];
    }

    public void Print()
    {
        Console.WriteLine($"{Name} ({Weight}г) — {Price:F2} Rub");
        Console.WriteLine($"   Состав: {Ingredients}");
        if (Tags.Length > 0)
            Console.WriteLine($"   Тэги: {string.Join(", ", Tags)}");
        Console.WriteLine($"   Время приготовления: {CookingTimeMinutes} мин\n");
    }

    public override string ToString()
    {
        return $"{Name} — {Price:F2} Rub";
    }
}