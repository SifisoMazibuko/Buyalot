using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buyalot.Models;
using Buyalot.DbConnection;

namespace Buyalot.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext modelDbEntities = new DataContext();

        public ProductCategoryModel find(int id)
        {
            return modelDbEntities.ProductCategoryModelSet.Find(id);
        }

        public List<ProductCategoryModel> findAll()
        {
            return modelDbEntities.ProductCategoryModelSet.ToList();
        }
    }
}