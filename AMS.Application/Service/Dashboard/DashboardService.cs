using AMS.Application.DTOs.Dashboard;
using AMS.Application.Repository.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
           return await _dashboardRepository.GetDashboardDataAsync();
        }
    }
}
