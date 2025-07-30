using AMS.Application.DTOs;
using AMS.Application.Repository.Assets;
using AMS.Domain.Entities;
using AMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AMSDbContext _context;

        public AssetRepository(AMSDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Asset dto)
        {
            try
            {

            await _context.assets.AddAsync(dto);
           return await _context.SaveChangesAsync()>0;

            }catch(Exception e)
            {

            }
            return true;
        }

        public async Task<bool> DeleteAsync(Asset asset)
        {
            _context.assets.Remove(asset); //imp to note:- Remove is synchronous, you cant make it await
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Asset>> GetAllAsync()
        {
           return await _context.assets.AsNoTracking().Include(c=>c.Category).AsNoTracking().Include(e=>e.AllocatedEmployee).AsNoTracking().ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
           return _context.assets.AsNoTracking().Include(c => c.Category).Include(e=>e.AllocatedEmployee).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Asset updatedAsset)
        {
            var local = _context.assets.Local.FirstOrDefault(entry => entry.Id == updatedAsset.Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(updatedAsset).State = EntityState.Modified;

            _context.assets.Update(updatedAsset); // now safe
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
