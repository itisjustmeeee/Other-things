using System; 
using System.Collections.Generic; 

namespace WarehouseSystem
{
    class Program
    {
        static void Main()
        {
            var manager = new WarehouseManager(); 
 
            manager.AddWarehouse(new Warehouse(1, WarehouseType.Общий, 1000, "Москва")); 
            manager.AddWarehouse(new Warehouse(2, WarehouseType.Холодный, 500, "СПб")); 
            manager.AddWarehouse(new Warehouse(3, WarehouseType.Сортировочный, 800, "Казань")); 
            manager.AddWarehouse(new Warehouse(4, WarehouseType.Утилизация, 300, "Екб"));
 
            var products = new List<Product> 
            { 
                new Product(101, 12, "Молоко", 3.0, 80, 50), 
                new Product(102, 10, "Хлеб", 0.5, 30, 2), 
                new Product(103, 11, "Консервы", 0.8, 150, -1),
                new Product(104, 15, "Сахар", 20.0, 10, 100),
                new Product(105, 33, "Доширак", 15.0, 27, -3),
                new Product(106, 27, "Сырок", 0.8, 20, 2)
            };

            Console.WriteLine("=== 1. Доставка новой партии товаров ===");
            var deliveryLog = manager.DeliverShipment(products);
            foreach (var msg in deliveryLog)
            {
                Console.WriteLine(msg);
            }

            Console.WriteLine("\nСостояние складов после доставки:");
            foreach (var w in manager.Warehouses)
            {
                w.DisplayInfo();
            }

            Console.WriteLine("\n=== 3. Перемещение конкретных товаров ===");
            var transferProducts = products.Where(p => p.Name == "Хлеб" || p.Name == "Сырок").ToList();
            var fromWarehouse = manager.Warehouses.First(w => w.Id == 3);
            var toWarehouse = manager.Warehouses.First(w => w.Id == 2);

            var transferLog = manager.TransferProducts(transferProducts, fromWarehouse, toWarehouse);
            foreach (var msg in transferLog)
            {
                Console.WriteLine(msg);
            }

            Console.WriteLine("\n=== 4. Перемещение просроченных товаров на утилизацию ===");
            var disposalLog = manager.DisposeExpiredProducts();
            foreach (var msg in disposalLog)
            {
                Console.WriteLine(msg);
            }

            Console.WriteLine("\n=== 2. Оптимизация всех сортировочных складов ===");
            var optimizeLog = manager.OptimizeSortingWarehouses();
            foreach (var msg in optimizeLog)
            {
                Console.WriteLine(msg);
            }

            /*Console.WriteLine("\n=== 6. Оптимизация конкретного склада: Сортировочный ===");
            var specificWarehouse = manager.Warehouses.First(w => w.Id == 3);
            var specificOptimizeLog = manager.OptimizeSortingWarehouses(specificWarehouse);
            foreach (var msg in specificOptimizeLog)
            {
                Console.WriteLine(msg);
            }*/

            Console.WriteLine("\n=== 5. Анализ сети складов ===");
            manager.AnalyzeNetwork();

            Console.WriteLine("\nСостояние складов после доставки:");
            foreach (var w in manager.Warehouses)
            {
                w.DisplayInfo();
            }

        }
    }
}