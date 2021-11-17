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

            CreateMap<ExtraViewModel, Extra>()
                 .ForMember(dest => dest.CategoryExtras, map => map.MapFrom(src => src.Categories.Select(x => new CategoryExtra() { IdCategory = x.Id, IdExtra = src.Id })));

            CreateMap<Extra, ExtraViewModel>()
                .ForMember(dest => dest.Categories, map => map.MapFrom(x => x.CategoryExtras.Select(x => x.Category)));

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, map => map.MapFrom(x => new CategoryViewModel() { Id = x.IdCategory, Name = (x.Category != null ? x.Category.Name : ""), Active = (x.Category != null ? x.Category.Active : false) }));

            CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.IdCategory, map => map.MapFrom(x => x.Category.Id))
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Item, ItemViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
