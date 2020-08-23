namespace PetStore.Services.Models.Product.OutputModels
{
    public class ListAllProductsByNameServiceModel
    {
        public string ProductType { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}