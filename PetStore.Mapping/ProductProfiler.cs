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

            this.CreateMap<Product, ListAllProductsByProductType>();
        }
    }
}