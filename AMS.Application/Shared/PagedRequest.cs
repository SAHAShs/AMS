using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Shared
{
    public class PagedRequest
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; } 
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public bool? IsAscending { get; set; } = true;
    }
}
