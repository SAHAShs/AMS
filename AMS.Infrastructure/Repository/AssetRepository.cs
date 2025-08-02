using AMS.Application.DTOs;
using AMS.Application.Repository.Assets;
using AMS.Application.Shared;
using AMS.Domain.Entities;
using AMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<List<Asset>> GetAllAssetsWithoutPageAsync()
        {
            return await _context.assets.AsNoTracking().ToListAsync();
        }

        public async Task<PagedResult<Asset>> GetAllAsync(PagedRequest req)
        {
           var query=  _context.assets.AsNoTracking()
                .Include(c => c.Category).AsNoTracking()
                .Include(e => e.AllocatedEmployee).AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(req.SearchTerm))
            {
                query = query.Where(a => a.Name.Contains(req.SearchTerm)
                ||  a.Id.ToString().Contains(req.SearchTerm)
                || a.Category.Name.Contains(req.SearchTerm)
                || a.Status.ToString().Contains(req.SearchTerm)
                || a.SerialNumber.Contains(req.SearchTerm)
                || a.PurchaseDate.ToString().Contains(req.SearchTerm));
            }

            int totalCount=query.Count();

            switch (req.SortColumn?.ToLower())
            {
                case "name":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                    break;
                case "purchasedate":
                    query = req.IsAscending == true ? query.OrderBy(a => a.PurchaseDate) : query.OrderByDescending(a => a.PurchaseDate);
                    break;
                case "serialnumber":
                    query = req.IsAscending == true ? query.OrderBy(a => a.SerialNumber) : query.OrderByDescending(a => a.SerialNumber);
                    break;
                case "status":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status);
                    break;
                case "category.name":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Category.Name) : query.OrderByDescending(a => a.Category.Name);
                    break;
                case "id":
                default:
                    query=req.IsAscending==true? query.OrderBy(a=>a.Id):query.OrderByDescending(a=>a.Id);
                    break;
            }
            var items=await query.Skip((req.PageNumber-1)* req.PageSize)
                .Take(req.PageSize)
                .ToListAsync();
            return  new PagedResult<Asset>
            {
                Items=items,
                TotalCount=totalCount
            };
        }

        public async Task<PagedResult<Asset>> GetByCategoryAsync(int? id, PagedRequest req)
        {
            var query = _context.assets.AsNoTracking()
                .Where(a=>a.CategoryId==id)
              .Include(c => c.Category).AsNoTracking()
              .Include(e => e.AllocatedEmployee).AsNoTracking()
              .AsQueryable();

            if (!string.IsNullOrWhiteSpace(req.SearchTerm))
            {
                query = query.Where(a => a.Name.Contains(req.SearchTerm)
                || a.Id.ToString().Contains(req.SearchTerm)
                || a.Category.Name.Contains(req.SearchTerm)
                || a.Status.ToString().Contains(req.SearchTerm)
                || a.SerialNumber.Contains(req.SearchTerm)
                || a.PurchaseDate.ToString().Contains(req.SearchTerm));
            }

            int totalCount = query.Count();

            switch (req.SortColumn?.ToLower())
            {
                case "name":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                    break;
                case "purchasedate":
                    query = req.IsAscending == true ? query.OrderBy(a => a.PurchaseDate) : query.OrderByDescending(a => a.PurchaseDate);
                    break;
                case "serialnumber":
                    query = req.IsAscending == true ? query.OrderBy(a => a.SerialNumber) : query.OrderByDescending(a => a.SerialNumber);
                    break;
                case "status":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status);
                    break;
                case "category.name":
                    query = req.IsAscending == true ? query.OrderBy(a => a.Category.Name) : query.OrderByDescending(a => a.Category.Name);
                    break;
                case "id":
                default:
                    query = req.IsAscending == true ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
            }
            var items = await query.Skip((req.PageNumber - 1) * req.PageSize)
                .Take(req.PageSize)
                .ToListAsync();
            return new PagedResult<Asset>
            {
                Items = items,
                TotalCount = totalCount
            };
            //return await _context.assets.AsNoTracking().Where(a=>a.CategoryId==id).Include(c => c.Category).AsNoTracking().Include(e => e.AllocatedEmployee).AsNoTracking().ToListAsync();
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
