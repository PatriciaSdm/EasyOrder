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
                .ForMember(dest => dest.Category, map => map.Ignore());

            CreateMap<Order, OrderViewModel>().ReverseMap();

            CreateMap<Item, ItemViewModel>()
                .ForMember(dest => dest.Order, map => map.Ignore())
                .ForMember(dest => dest.Extras, map => map.MapFrom(x => x.ItemExtras.Select(y => new ExtraViewModel() { Id = y.IdExtra, Name = (y.Extra != null ? y.Extra.Name : ""), Active = (y.Extra != null ? y.Extra.Active : false) })));

            CreateMap<ItemViewModel, Item>()
                .ForMember(dest => dest.ItemExtras, map => map.MapFrom(x => x.Extras.Select(y => new ItemExtra() { IdExtra = y.Id, IdItem = x.Id })));
        }
    }
}
