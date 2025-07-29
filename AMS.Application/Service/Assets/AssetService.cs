using AMS.Application.DTOs;
using AMS.Application.Repository.Assets;
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

        public async Task<bool> DeleteAssetAsync(int id)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return false;


            await _assetRepository.DeleteAsync(asset);
            return true;
        
        }

        public async Task<List<AssetDto>> GetAllAssetsAsync()
        {
            return _mapper.Map<List<AssetDto>>(await _assetRepository.GetAllAsync());
        }

        public async Task<AssetDto?> GetAssetByIdAsync(int id)
        {
            return  _mapper.Map<AssetDto>( _assetRepository.GetByIdAsync(id));
        }

        public async Task<bool> UpdateAssetAsync(int id,AssetDto dto)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return false;

            _mapper.Map(dto, asset);
            await _assetRepository.UpdateAsync(id,asset);
            return true;
        }
    }
}
