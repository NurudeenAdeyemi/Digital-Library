using Core.Interfaces.Repositories;
using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryContext _libraryContext;

        public CategoryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Category AddCategory(Category category)
        {
            _libraryContext.Categories.Add(category);
            _libraryContext.SaveChanges();
            return category;
        }
        public IEnumerable<Category> GetSelectedCategories(IList<int> ids)
        {
            return _libraryContext.Categories
                .Where(e => ids.Contains(e.Id)).ToList();
        }

        public void DeleteCategory(int id)
        {
            var category = _libraryContext.Categories.SingleOrDefault(c => c.Id == id);
            if(category != null)
            {
                _libraryContext.Categories.Remove(category);
                _libraryContext.SaveChanges();
            }
        }

        public IList<Category> GetCategories()
        {
            return _libraryContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _libraryContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category UpdateCategory(Category category)
        {
            _libraryContext.Categories.Update(category);
            _libraryContext.SaveChanges();
            return category;
        }
    }
}
