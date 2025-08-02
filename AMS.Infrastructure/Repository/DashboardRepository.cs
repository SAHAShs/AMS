using AMS.Application.DTOs.Dashboard;
using AMS.Application.Repository.Dashboard;
using AMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AMSDbContext _context;
        public DashboardRepository(AMSDbContext context)
        {
            _context=context;
        }
        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            var model = new DashboardViewModel();

            // Summary
            var summary =  _context.Set<DashboardSummaryDto>()
                                        .FromSqlRaw("EXEC sp_GetDashboardSummary")
                                        .AsNoTracking().AsEnumerable().First();

            if (summary != null)
            {
                model.TotalAssets = summary.TotalAssets;
                model.InUseAssets = summary.InUseAssets;
                model.UnderMaintenance = summary.UnderMaintenance;
                model.RetiredAssets = summary.RetiredAssets;
                model.AvailableAssets = summary.AvailableAssets;
            }

          

            // Category-wise
            var catList = await _context.Set<CategoryWiseCountDto>()
                                        .FromSqlRaw("EXEC sp_GetCategoryWiseCount")
                                        .AsNoTracking()
                                        .ToListAsync();

            model.CategoryWiseCount = catList.ToDictionary(x => x.CategoryName, x => x.AssetCount);

            return model;
        }
    }
}
