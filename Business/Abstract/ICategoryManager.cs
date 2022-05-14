using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void Add(Category category);
        void Remove(Category category);
        void Update(Category category);

    }
}
