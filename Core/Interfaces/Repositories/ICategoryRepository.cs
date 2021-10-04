using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Category GetCategory(int id);

        public IList<Category> GetCategories();

        public Category UpdateCategory(Category category);

        public Category AddCategory(Category category);

        public void DeleteCategory(int id);


    }
}
