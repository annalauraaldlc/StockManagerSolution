﻿using AutoMapper;
using StockManager.AdministrationContext.Domain.ProductAggregate;

namespace StockManager.AdministrationContext.Infra.Data.Entities
{
    public class ProductProfile : Profile
    {
        public ProductProfile() : base()
        {
            CreateMap<ProductTable, Product>();
        }
    }
}
