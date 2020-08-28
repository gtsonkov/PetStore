using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;
using System;

namespace PetStore.Mapping
{
    public class ProductProfiler : Profile
    {
        public ProductProfiler()
        {
            this.CreateMap<AddProductServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x=> Enum.Parse(typeof(ProductType),x.ProductType)));

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductId, y=> y.MapFrom(x => x.Id))
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
               .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Id));

            this.CreateMap<EditProductServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));

            this.CreateMap<Product, EditProductServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<ListAllProductsByNameServiceModel, ListAllProductsServiceModel>();
        }
    }
}