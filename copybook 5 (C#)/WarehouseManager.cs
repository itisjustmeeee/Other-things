using System; 
using System.Collections.Generic; 
using System.Linq;

namespace WarehouseSystem
{
    public class WarehouseManager
    {
        private List<Warehouse> _warehouses = new List<Warehouse>(); 
 
        public IReadOnlyList<Warehouse> Warehouses => _warehouses.AsReadOnly(); 
 
        public void AddWarehouse(Warehouse warehouse) 
        { 
            _warehouses.Add(warehouse); 
        } 

        public List<string> DeliverShipment(List<Product> products) 
        { 
            var log = new List<string>(); 
 
            if (!products.Any()) 
                return log; 
 
            bool hasShortExpiry = products.Any(p => p.DaysUntilExpiry < 30); 
            bool hasLongExpiry = products.Any(p => p.DaysUntilExpiry >= 30); 
 
            WarehouseType targetType; 
 
            if (!hasShortExpiry && hasLongExpiry) 
                targetType = WarehouseType.Общий; 
            else if (hasShortExpiry && !hasLongExpiry) 
                targetType = WarehouseType.Холодный; 
            else 
                targetType = WarehouseType.Сортировочный; 
 
            var suitableWarehouses = _warehouses 
                .Where(w => w.Type == targetType && w.FreeVolume >= products.Sum(p => p.UnitVolume)) 
                .OrderBy(w => w.FreeVolume) 
                .ToList(); 
 
            if (!suitableWarehouses.Any()) 
            { 
                log.Add("Ошибка: нет подходящего склада с достаточным свободным объёмом."); 
                return log; 
            } 
 
            var targetWarehouse = suitableWarehouses.First(); 
            targetWarehouse.AddProducts(products, log); 
            log.Insert(0, $"Поставка направлена на {targetType} склад Id={targetWarehouse.Id}"); 
 
            return log; 
        } 
        public List<string> OptimizeSortingWarehouses(Warehouse? specificWarehouse = null) 
        { 
            var log = new List<string>(); 
            var sortingWarehouses = specificWarehouse != null ? (specificWarehouse.Type == WarehouseType.Сортировочный ? new[] { specificWarehouse } : Array.Empty<Warehouse>()) : _warehouses.Where(w => w.Type == WarehouseType.Сортировочный); 
 
            foreach (var sorting in sortingWarehouses) 
            { 
                var shortExpiry = sorting.Products.Where(p => p.DaysUntilExpiry < 30).ToList(); 
                var longExpiry = sorting.Products.Where(p => p.DaysUntilExpiry >= 30).ToList(); 
 
                if (shortExpiry.Any()) 
                { 
                    var cold = _warehouses.FirstOrDefault(w => w.Type == WarehouseType.Холодный && w.FreeVolume >= shortExpiry.Sum(p => p.UnitVolume)); 
                    if (cold != null) 
                        sorting.RemoveProducts(shortExpiry, log, cold); 
                } 
 
                if (longExpiry.Any()) 
                { 
                    var general = _warehouses.FirstOrDefault(w => w.Type == WarehouseType.Общий && w.FreeVolume >= longExpiry.Sum(p => p.UnitVolume)); 
                    if (general != null) 
                        sorting.RemoveProducts(longExpiry, log, general); 
                } 
            } 
 
            return log; 
        } 
        public List<string> TransferProducts(List<Product> products, Warehouse from, Warehouse to) 
        { 
            var log = new List<string>(); 
            if (to.FreeVolume < products.Sum(p => p.UnitVolume)) 
            { 
                log.Add("Ошибка: недостаточно места на целевом складе."); 
                return log; 
            } 
 
            from.RemoveProducts(products, log, to); 
            return log; 
        } 
 
        public List<string> DisposeExpiredProducts(Warehouse? specificWarehouse = null) 
        { 
            var log = new List<string>(); 
            var targetWarehouses = specificWarehouse != null 
                ? (new[] { specificWarehouse }) 
                : _warehouses.Where(w => w.Type != WarehouseType.Утилизация); 
 
            var disposalWarehouses = _warehouses.Where(w => w.Type == WarehouseType.Утилизация).ToList(); 
 
            foreach (var warehouse in targetWarehouses) 
            { 
                var expired = warehouse.Products.Where(p => p.DaysUntilExpiry <= 0).ToList(); 
                if (expired.Any() && disposalWarehouses.Any()) 
                { 
                    var disposal = disposalWarehouses.OrderBy(d => d.FreeVolume).First(); 
                    warehouse.RemoveProducts(expired, log, disposal); 
                } 
            } 
 
            return log; 
        } 
 
        public void AnalyzeNetwork() 
        { 
            foreach (var w in _warehouses) 
            { 
                var issues = new List<string>(); 
 
                if (w.Type == WarehouseType.Сортировочный && w.Products.Any()) 
                { 
                    bool hasShort = w.Products.Any(p => p.DaysUntilExpiry < 30); 
                    bool hasLong = w.Products.Any(p => p.DaysUntilExpiry >= 30); 
                    if (hasShort || hasLong) 
                        issues.Add("требуется оптимизационное перемещение"); 
                } 
 
                if (w.Products.Any(p => p.DaysUntilExpiry <= 0)) 
                    issues.Add("требуется перемещение просроченных товаров"); 
 
                Console.WriteLine($"Склад {w.Id} ({w.Type}): " + (issues.Any() ? $"нарушения есть — {string.Join(", ", issues)}" : "нарушений нет")); 
            } 
        } 
    }
}