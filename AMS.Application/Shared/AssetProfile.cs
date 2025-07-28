using AMS.Application.DTOs;
using AMS.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Shared
{
    public class AssetProfile:Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>().ReverseMap();
        }
    }
}
