using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;
using System.Collections.Generic;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        public void AddProduct(AddProductInputServiceModel model);

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);

        public ICollection<ListAllProductsServiceModel> GetAll();

        public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchString, bool caseSensitive);

        public bool EditProduct(string id, EditProductServiceModel model);

        public bool RemoveById(string id);

        public bool RemoveByName(string name);
    }
}