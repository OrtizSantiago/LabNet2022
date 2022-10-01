using LabNet.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.Linq.Logic
{
    public class CategoryLogic : BaseLogic
    {
        public IEnumerable<Categories> CategoriesByProducts()
        {
            var result = from category in context.Categories
                         join product in context.Products
                         on category.CategoryID equals product.CategoryID
                         select category;

            return result;
        }
    }
}
