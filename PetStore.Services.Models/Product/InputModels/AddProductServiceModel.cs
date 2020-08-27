﻿using PetStore.Common;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Services.Models.Product.InputModels
{
    public class AddProductServiceModel
    {
        [Required]
        public string ProductType { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ProductNameMaxLenght)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductPriceMin, GlobalConstants.ProductPriceMax)]
        public decimal Price { get; set; }
    }
}