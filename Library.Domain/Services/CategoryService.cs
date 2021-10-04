using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public BaseResponse AddCategory(CreateCategoryRequestModel model)
        {
            var category = new Category
            {
                Name = model.Name
            };
            _categoryRepository.AddCategory(category);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public IList<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public CategoryModel GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            return new CategoryModel
            {
                Name = category.Name,
            };
        }

        public BaseResponse UpdateCategory(int id, UpdateCategoryRequestModel model)
        {
            var category = _categoryRepository.GetCategory(id);
            category.Name = model.Name;
            _categoryRepository.UpdateCategory(category);

            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
             };
        }
    }
}
