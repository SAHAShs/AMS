using AMS.Domain.Entities;
using AMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.DTOs
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int CategoryId { get; set; }
        public AssetCategory Category { get; set; }
        public AssetStatus Status { get; set; } = AssetStatus.Available;
        public DateTime PurchaseDate { get; set; }
        public int? AllocatedTo { get; set; }

        public Employee? AllocatedEmployee { get; set; }
    }
}
