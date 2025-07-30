using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Asset> AssignedAssets { get; set; } = new List<Asset>();
    }
}
