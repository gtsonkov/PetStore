using Microsoft.EntityFrameworkCore;
using PetStore.Common;
using PetStore.Models;
using System.Reflection;

namespace PetStore.Data
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext()
        {

        }

        public PetShopDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientProducts> ClientProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}