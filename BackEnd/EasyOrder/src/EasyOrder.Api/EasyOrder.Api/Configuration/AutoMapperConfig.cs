using AutoMapper;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
