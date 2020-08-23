using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.Data.EntityConfigurations
{
    public class ClientProductsConfiguration : IEntityTypeConfiguration<ClientProducts>
    {
        public void Configure(EntityTypeBuilder<ClientProducts> builder)
        {
            builder.HasKey(cp => new {cp.ProductId, cp.ClientId});

            builder.HasOne(p => p.Product)
                .WithMany(c => c.ClientProducts)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(c => c.Client)
                .WithMany(cp => cp.ClientProducts)
                .HasForeignKey(c => c.ClientId);

            builder.HasOne(o => o.Order)
                .WithMany(cpo => cpo.ClientProducts)
                .HasForeignKey(o => o.OrderId);
        }
    }
}