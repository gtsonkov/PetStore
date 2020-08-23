using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProducts>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TownMaxLenght)]
        public string Town { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AddressMaxLenght)]
        public string Address { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<ClientProducts> ClientProducts { get; set; }

        public decimal TotalPrice => ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity);
    }
}