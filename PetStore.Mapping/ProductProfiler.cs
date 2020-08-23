using AutoMapper;
using PetStore.Models;
using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;

namespace PetStore.Mapping
{
    public class ProductProfiler : Profile
    {
        public ProductProfiler()
        {
            this.CreateMap<AddProductInputServiceModel, Product>();

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString())); ;
        }
    }
}