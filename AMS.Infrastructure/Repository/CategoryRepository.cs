using AMS.Application.Repository.Category;
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
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AMSDbContext _context;

        public CategoryRepository(AMSDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(AssetCategory dto)
        {
            try
            {

                await _context.categories.AddAsync(dto);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception e)
            {

            }
            return true;
        }

        public async Task<bool> DeleteAsync(AssetCategory asset)
        {
            _context.categories.Remove(asset); //imp to note:- Remove is synchronous, you cant make it await
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AssetCategory>> GetAllAsync()
        {
            return await _context.categories.AsNoTracking().Include(c => c.Assets).AsNoTracking().ToListAsync();
        }

        public  AssetCategory? GetByIdAsync(int id)
        {
            return _context.categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(AssetCategory updatedAssetCategory)
        {
            _context.categories.Update(updatedAssetCategory);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
