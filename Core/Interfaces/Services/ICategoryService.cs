using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICategoryService
    {
        public CategoryModel GetCategory(int id);

        public IList<Category> GetCategories();

        public BaseResponse UpdateCategory(int id,UpdateCategoryRequestModel model);

        public BaseResponse AddCategory(CreateCategoryRequestModel model);

        public void DeleteCategory(int id);
    }
}
