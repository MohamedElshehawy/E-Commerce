﻿using AutoMapper;
using E_Commerce.Core.DataTransferObjects;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Basket;

namespace E_Commerce.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductBrand, BrandTypeDto>();
            CreateMap<ProductType, BrandTypeDto>();



            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=> d.BrandName , o=> o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=> d.TypeName , o=> o.MapFrom(s=>s.productType.Name))
                .ForMember(d=> d.PictureUrl,o=>o.MapFrom<PictureUrlResolver>());


            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
