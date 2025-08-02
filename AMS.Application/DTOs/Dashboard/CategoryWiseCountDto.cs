using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.DTOs.Dashboard
{
    public class CategoryWiseCountDto
    {
        public string CategoryName { get; set; }
        public int AssetCount { get; set; }
    }
}
