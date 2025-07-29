using AMS.Application.DTOs;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Category
{
    public interface ICategoryService
    {
        Task<List<AssetCategory>> GetAllAsync();
        AssetCategory? GetByIdAsync(int id);
        Task<bool> AddAsync(AssetCategory dto);
        Task<bool> UpdateAsync(int id, AssetCategory dto);
        Task<bool> DeleteAsync(int id);
    }
}
