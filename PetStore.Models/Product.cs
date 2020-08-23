using PetStore.Common;
using PetStore.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProducts>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ProductNameMaxLenght)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductPriceMin,GlobalConstants.ProductPriceMax)]
        public decimal Price { get; set; }

        public virtual ICollection<ClientProducts> ClientProducts { get; set; }
    }
}