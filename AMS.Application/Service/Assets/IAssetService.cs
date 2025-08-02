using AMS.Application.DTOs;
using AMS.Application.Shared;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Assets
{
    public interface IAssetService
    {
        Task<PagedResult<AssetDto>> GetAllAssetsAsync(PagedRequest req);
        Task<List<AssetDto>> GetAllAssetsWithoutPageAsync();
        Task<PagedResult<AssetDto>> GetAssetsByCategoryAsync(int? id,PagedRequest req);
        Task<AssetDto?> GetAssetByIdAsync(int id);
        Task<bool> AddAssetAsync(AssetDto dto);
        Task<bool> UpdateAssetAsync(int id, AssetDto dto);
        Task<bool> DeleteAssetAsync(int id);

        Task<bool> UnassignAsset(int id);
        Task<bool> AssignAsset(AssetDto dto);
    }
}
