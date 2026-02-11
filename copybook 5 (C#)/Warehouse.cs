using System; 
using System.Collections.Generic; 
using System.Linq;

namespace WarehouseSystem
{
    public class Warehouse
    {
        public int Id {get; set;}
        public WarehouseType Type {get; set;}
        public double Capacity {get; set;}
        public string Address {get; set;}

        private List<Product> _products = new List<Product>();
        public IReadOnlyList<Product> Products => _products.AsReadOnly();

        public Warehouse(int id, WarehouseType type, double capacity, string address)
        {
            Id = id;
            Type = type;
            Capacity = capacity;
            Address = address;
        }

        public void Update(WarehouseType type, double capacity, string address)
        {
            Type = type;
            Capacity = capacity;
            Address = address;
        }

        public double OccupiedVolume => _products.Sum(p => p.UnitVolume * 1);

        public double FreeVolume => Capacity - OccupiedVolume;

        public void AddProducts(IEnumerable<Product> products, List<string> log)
        {
            foreach (var product in products)
            {
                _products.Add(product);
                log.Add($"{product} объем - {product.UnitVolume} -> на склад {Id} ({Type}) по адресу {Address}");
            }
        }

        public void RemoveProducts(IEnumerable<Product> products, List<string> log, Warehouse targetWarehouse)
        {
            foreach (var product in products)
            {
                if (_products.Remove(product))
                {
                    log.Add($"{product} объем - {product.UnitVolume} со склада {Id} ({Type}) -> на склад {targetWarehouse.Id} ({targetWarehouse.Type})");
                    targetWarehouse._products.Add(product);
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Склад ID - {Id}, Тип - {Type}, Объем - {Capacity}, Занято - {OccupiedVolume}, Свободно - {FreeVolume}, Адрес - {Address}");
            Console.WriteLine($"Товаров на складе: {_products.Count}");
        }

        public double CalculateTotalValue()
        {
            return _products.Sum(p => p.UnitPrice);
        }
    }
}