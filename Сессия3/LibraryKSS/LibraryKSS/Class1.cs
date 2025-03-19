using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryKSS
{
    public class Warehouse
    {
        private readonly СкладEntities _context;

        public Warehouse()
        {
            _context = new СкладEntities();
        }

        // Метод 1: Подсчет общего количества товара на всех складах
        public int CalculateTotalQuantityForProduct(int productID)
        {
            return _context.СкладскиеЗаписи
                .Where(s => s.ID_товара == productID)
                .Select(s => s.Количество)
                .DefaultIfEmpty(0)
                .Sum();
        }

        // Метод 2: Подсчет количества товара на конкретном складе
        public int CalculateQuantityForProductInWarehouse(int productID, int warehouseID)
        {
            return _context.СкладскиеЗаписи
                .Where(s => s.ID_товара == productID && s.ID_склада == warehouseID)
                .Select(s => s.Количество)
                .DefaultIfEmpty(0)
                .Sum();
        }

        // Метод 3: Подсчет суммы стоимости товаров на всех складах
        public decimal CalculateTotalValueForProduct(int productID)
        {
            var product = _context.Товары.FirstOrDefault(p => p.ID_товара == productID);
            if (product == null)
                return 0;

            int totalQuantity = CalculateTotalQuantityForProduct(productID);
            return totalQuantity * product.Цена;
        }

        // Метод 4: Подсчет суммы стоимости товаров на конкретном складе
        public decimal CalculateValueForProductInWarehouse(int productID, int warehouseID)
        {
            var product = _context.Товары.FirstOrDefault(p => p.ID_товара == productID);
            if (product == null)
                return 0;

            int quantity = CalculateQuantityForProductInWarehouse(productID, warehouseID);
            return quantity * product.Цена;
        }

        // Метод 5: Подсчет количества товаров по категориям на всех складах
        public Dictionary<string, int> CalculateQuantityByCategory()
        {
            return _context.СкладскиеЗаписи
                .Join(_context.Товары,
                    stock => stock.ID_товара,
                    product => product.ID_товара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество));
        }

        // Метод 6: Подсчет количества товаров по категориям на конкретном складе
        public Dictionary<string, int> CalculateQuantityByCategoryInWarehouse(int warehouseID)
        {
            return _context.СкладскиеЗаписи
                .Where(s => s.ID_склада == warehouseID)
                .Join(_context.Товары,
                    stock => stock.ID_товара,
                    product => product.ID_товара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество));
        }

        // Метод 7: Получение списка товаров на складе с их количеством
        public Dictionary<string, int> GetProductsInWarehouse(int warehouseID)
        {
            return _context.СкладскиеЗаписи
                .Where(s => s.ID_склада == warehouseID)
                .Join(_context.Товары,
                    stock => stock.ID_товара,
                    product => product.ID_товара,
                    (stock, product) => new { product.Наименование, stock.Количество })
                .ToDictionary(x => x.Наименование, x => x.Количество);
        }

        // Метод 8: Получение списка зон хранения на складе
        public List<string> GetStorageZonesInWarehouse(int warehouseID)
        {
            return _context.ЗоныХранения
                .Where(z => z.ID_склада == warehouseID)
                .Select(z => z.НаименованиеЗоны)
                .ToList();
        }

        // Метод 9: Получение списка товаров в зоне хранения
        public Dictionary<string, int> GetProductsInStorageZone(int zoneID)
        {
            return _context.СкладскиеЗаписи
                .Where(s => s.ID_зоны == zoneID)
                .Join(_context.Товары,
                    stock => stock.ID_товара,
                    product => product.ID_товара,
                    (stock, product) => new { product.Наименование, stock.Количество })
                .ToDictionary(x => x.Наименование, x => x.Количество);
        }

        // Метод 10: Получение списка всех складов
        public List<string> GetAllWarehouses()
        {
            return _context.Склады
                .Select(w => w.Наименование)
                .ToList();
        }
    }
}
