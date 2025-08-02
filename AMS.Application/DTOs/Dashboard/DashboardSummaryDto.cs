using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public int TotalAssets { get; set; }
        public int InUseAssets { get; set; }
        public int UnderMaintenance { get; set; }
        public int RetiredAssets { get; set; }
        public int AvailableAssets { get; set; }
    }
}
