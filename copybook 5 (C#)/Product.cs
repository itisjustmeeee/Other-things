using System;

namespace WarehouseSystem
{
    public class Product
    {
        public int Id {get; set;}
        public int SupplierId {get; set;}
        public string Name {get; set;} = string.Empty;
        public double UnitVolume {get; set;}
        public double UnitPrice {get; set;}
        public int DaysUntilExpiry {get; set;}

        public Product(int id, int supplierId, string name, double unitVolume, double unitPrice, int daysUntilExpiry)
        {
            Id = id;
            SupplierId = supplierId;
            Name = name;
            UnitVolume = unitVolume;
            UnitPrice = unitPrice;
            DaysUntilExpiry = daysUntilExpiry;
        }

        public void Update(string name, double unitVolume, double unitPrice, int daysUntilExpiry)
        {
            Name = name;
            UnitVolume = unitVolume;
            UnitPrice = unitPrice;
            DaysUntilExpiry = daysUntilExpiry;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Товар: ID - {Id}, Название - '{Name}', Объем ед. = {UnitVolume}, Цена ед. = {UnitPrice}," + 
                $"Дней до конца срока годности: {DaysUntilExpiry}, ID поставщика - {SupplierId}");
        }

        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}