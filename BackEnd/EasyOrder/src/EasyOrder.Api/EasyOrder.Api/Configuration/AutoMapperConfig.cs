using AutoMapper;
using EasyOrder.Api.DTOs.Request;
using EasyOrder.Api.DTOs.Response;
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
            CreateMap<Category, KeyValueResponseDTO>()
                .ForMember(dest => dest.Key, map => map.MapFrom(x => x.Id))
                .ForMember(dest => dest.Value, map => map.MapFrom(x => x.Name));

            CreateMap<ExtraRequestDTO, Extra>()
                 .ForMember(dest => dest.CategoryExtras, map => map.MapFrom(src => src.Categories.Select(x => new CategoryExtra() { IdCategory = x, IdExtra = src.Id })));
            CreateMap<Extra, ExtraResponseDTO>()
                .ForMember(dest => dest.Categories, map => map.MapFrom(x => x.CategoryExtras.Select(x => x.Category)));

            CreateMap<Extra, KeyValueResponseDTO>()
                .ForMember(dest => dest.Key, map => map.MapFrom(x => x.Id))
                .ForMember(dest => dest.Value, map => map.MapFrom(x => x.Name));


            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();

            CreateMap<Product, KeyValueResponseDTO>()
                .ForMember(dest => dest.Key, map => map.MapFrom(x => x.Id))
                .ForMember(dest => dest.Value, map => map.MapFrom(x => x.Name));

            CreateMap<Order, OrderResponseDTO>();
            CreateMap<OrderRequestDTO, Order>();

            CreateMap<Item, ItemResponseDTO>()
                .ForMember(dest => dest.Extras, map => map.MapFrom(x => x.ItemExtras.Select(x => x.Extra)));
            CreateMap<ItemRequestDTO, Item>()
                .ForMember(dest => dest.ItemExtras, map => map.MapFrom(src => src.Extras.Select(x => new ItemExtra() { IdExtra = x, IdItem = src.Id })));
        }
    }
}
