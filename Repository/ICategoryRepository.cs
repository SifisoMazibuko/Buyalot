using System.Collections.Generic;
using Buyalot.Models;

namespace Buyalot.Repository
{
    public interface ICategoryRepository
    {
        List<ProductCategoryModel> findAll();
        ProductCategoryModel find(int id);
    }
}
