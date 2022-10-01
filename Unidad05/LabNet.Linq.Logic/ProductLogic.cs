using LabNet.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.Linq.Logic
{
    public class ProductLogic : BaseLogic
    {
        public IEnumerable<Products> ProductsWithOutStock()
        {
            var products = context.Products.ToList();
            var list = from product in products
                       where product.UnitsInStock == 0
                       select product;
            return list;
        }

        public IEnumerable<Products> ProductsWithStockAndCost3()
        {
            var result = context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
            return result;
        }

        public Products ProductId789()
        {
            var result = context.Products.Where(p => p.ProductID == 789).ToList().FirstOrDefault();
            return result;
        }

        public IEnumerable<Products> ProductsOrderByName()
        {
            var result = context.Products.ToList().OrderBy(p => p.ProductName).ToList();
            return result;
        }

        public IEnumerable<Products> ProductsOrderByStock()
        {
            var result = from product in context.Products
                         orderby product.UnitsInStock descending
                         select product;

            return result;
        }

        public Products FirstProduct()
        {
            var result = context.Products.First();
            return result;
        }

    }
}
