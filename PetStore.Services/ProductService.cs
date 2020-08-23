using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetShopDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(PetShopDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            Product currProduct = this._mapper.Map<Product>(model);

            this._db.Products.Add(currProduct);
            this._db.SaveChanges();
        }

        public ICollection<ListAllProductsByProductType> ListAllByProductType(string type)
        {
            ProductType currProductType;

            bool isValidProductType = Enum.TryParse(type, true, out currProductType);

            if (!isValidProductType)
            {
                throw new ArgumentException(ExceptionMessages.NoSuchProductType);
            }

            var result = this._db.Products
                .Where(p => p.ProductType == currProductType)
                .ProjectTo<ListAllProductsByProductType>(this._mapper.ConfigurationProvider)
                .ToList();

            return result;
        }
    }
}