namespace PetStore.Models
{
    public class ClientProducts
    {
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}