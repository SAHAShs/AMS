using AMS.Application.DTOs;
using AMS.Application.Repository.Assets;
using AMS.Application.Shared;
using AMS.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Assets
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;
        public AssetService(IAssetRepository assetRepository,IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAssetAsync(AssetDto dto)
        {
            return await _assetRepository.AddAsync(_mapper.Map<Asset>(dto));
        }

        public async Task<bool> AssignAsset(AssetDto asset)
        {
            asset.Status = Domain.Enums.AssetStatus.Allocated;
            await _assetRepository.UpdateAsync(_mapper.Map<Asset>(asset));
            return true;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return false;


            await _assetRepository.DeleteAsync(asset);
            return true;
        
        }

        public async Task<PagedResult<AssetDto>> GetAllAssetsAsync(PagedRequest req)
        {
           var assets = await _assetRepository.GetAllAsync(req);
            return new PagedResult<AssetDto>
            {
                Items = _mapper.Map<List<AssetDto>>(assets.Items),
                TotalCount = assets.TotalCount
            };
        }

        public async Task<List<AssetDto>> GetAllAssetsWithoutPageAsync()
        {
            return _mapper.Map<List<AssetDto>>(await _assetRepository.GetAllAssetsWithoutPageAsync());
        }

        public async Task<AssetDto?> GetAssetByIdAsync(int id)
        {
            var asset =await _assetRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AssetDto>(asset);
            return dto;
        }

        public async Task<PagedResult<AssetDto>> GetAssetsByCategoryAsync(int? id,PagedRequest req)
        {
            var assets = await _assetRepository.GetByCategoryAsync(id,req);
            return new PagedResult<AssetDto>
            {
                Items = _mapper.Map<List<AssetDto>>(assets.Items),
                TotalCount = assets.TotalCount
            };
        }

        public async Task<bool> UnassignAsset(int id)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return false;
            asset.Status = Domain.Enums.AssetStatus.Available;
            asset.AllocatedTo = null;
            await _assetRepository.UpdateAsync(asset);
            return true;
        }

        public async Task<bool> UpdateAssetAsync(int id,AssetDto dto)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return false;

            _mapper.Map(dto, asset);
            await _assetRepository.UpdateAsync(asset);
            return true;
        }
    }
}
