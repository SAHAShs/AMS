using AMS.Application.DTOs;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Repository.Assets
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAllAsync();
       Task<Asset?> GetByIdAsync(int id);
        Task<bool> AddAsync(Asset dto);
        Task<bool> UpdateAsync(int id,Asset dto);
        Task<bool> DeleteAsync(Asset asset);
    }
}
