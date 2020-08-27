using PetStore.Models.Enumerations;

namespace PetStore.Services.Models.Product.OutputModels
{
    public class ListAllProductsServiceModel
    {
        public string ProductId { get; set; }

        public string ProductType { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}