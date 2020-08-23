using PetStore.Common;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class ClientProducts
    {
        [Required]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Range(GlobalConstants.MinQuantity,GlobalConstants.MaxQuantity)]
        public int Quantity { get; set; }
    }
}