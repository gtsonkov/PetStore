using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.Services.Interfaces;
using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class ProductService : IProductService
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
            Product currProduct = null;
            try
            {
                currProduct = this._mapper.Map<Product>(model);
                
            }
            catch (Exception)
            {

                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            this._db.Products.Add(currProduct);
            this._db.SaveChanges();
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchString, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> result;

            if (caseSensitive)
            {
                result = this._db.Products
                    .Where(p => p.Name.Contains(searchString))
                    .ProjectTo<ListAllProductsByNameServiceModel>(this._mapper.ConfigurationProvider)
                    .ToList();

                return result;
            }

            result = this._db.Products
                    .Where(p => p.Name.
                                    ToLower()
                                    .Contains(searchString.ToLower()))
                    .ProjectTo<ListAllProductsByNameServiceModel>(this._mapper.ConfigurationProvider)
                    .ToList();

            return result;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType currProductType;

            bool isValidProductType = Enum.TryParse(type, true, out currProductType);

            if (!isValidProductType)
            {
                throw new ArgumentException(ExceptionMessages.NoSuchProductType);
            }

            var result = this._db.Products
                .Where(p => p.ProductType == currProductType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>(this._mapper.ConfigurationProvider)
                .ToList();

            return result;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllProducts()
        {
            var result = this._db.Products
                .ProjectTo<ListAllProductsByProductTypeServiceModel>(this._mapper.ConfigurationProvider)
                .ToList();

            return result;
        }

        public bool RemoveById(string id)
        {
            var productToRemove = this._db.Products.FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.NoProductWithGivenId);
            }

            this._db.Products.Remove(productToRemove);

            int rowsAffected = this._db.SaveChanges();

            if (rowsAffected == 0)
            {
                return false;
            }

            return true;
        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this._db.Products.FirstOrDefault(p => p.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.NoProductWithGivenId);
            }

            this._db.Products.Remove(productToRemove);

            int rowsAffected = this._db.SaveChanges();

            return rowsAffected > 0;
        }

        public bool EditProduct(string id, EditProductServiceModel model)
        {
            Product currProduct = null;

            try
            {
                currProduct = this._mapper.Map<Product>(model);
            }
            catch (Exception)
            {

                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productToUpdate = this._db.Products.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.NoProductWithGivenId);
            }

            productToUpdate = currProduct;

            int affectedRows = this._db.SaveChanges();

            return affectedRows > 0;
        }
    }
}