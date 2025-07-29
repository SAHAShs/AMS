using AMS.Application.Repository.Assets;
using AMS.Application.Repository.Category;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> AddAsync(AssetCategory dto)
        {
           return await _categoryRepository.AddAsync(dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asset =  _categoryRepository.GetByIdAsync(id);
            if (asset == null)
                return false;


            await _categoryRepository.DeleteAsync(asset);
            return true;
        }

        public async Task<List<AssetCategory>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public AssetCategory? GetByIdAsync(int id)
        {
          return  _categoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, AssetCategory dto)
        {
            var asset =  _categoryRepository.GetByIdAsync(id);
            if (asset == null)
                return false;

            
            await _categoryRepository.UpdateAsync(id, asset);
            return true;
        }
    }
}
