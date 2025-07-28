using AMS.Application.DTOs;
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
        Task<List<AssetDto>> GetAllAssetsAsync();
        Task<AssetDto?> GetAssetByIdAsync(int id);
        Task<bool> AddAssetAsync(AssetDto dto);
        Task<bool> UpdateAssetAsync(int id, AssetDto dto);
        Task<bool> DeleteAssetAsync(int id);
    }
}
