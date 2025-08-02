using AMS.Application.DTOs;
using AMS.Application.Shared;
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
        Task<PagedResult<Asset>> GetAllAsync(PagedRequest req);

        Task<List<Asset>> GetAllAssetsWithoutPageAsync();
        Task<PagedResult<Asset>> GetByCategoryAsync(int? id,PagedRequest req);
        Task<Asset?> GetByIdAsync(int id);
        Task<bool> AddAsync(Asset dto);
        Task<bool> UpdateAsync(Asset dto);
        Task<bool> DeleteAsync(Asset asset);
    }
}
