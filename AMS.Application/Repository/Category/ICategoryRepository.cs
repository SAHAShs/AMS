using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Repository.Category
{
    public interface ICategoryRepository
    {
        Task<List<AssetCategory>> GetAllAsync();
        AssetCategory? GetByIdAsync(int id);
        Task<bool> AddAsync(AssetCategory dto);
        Task<bool> UpdateAsync(AssetCategory dto);
        Task<bool> DeleteAsync(AssetCategory asset);
    }
}
