using Catalog.API.Infrastructure.EntityConfigurations;
using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());

            modelBuilder.Entity<CatalogBrand>().HasData(
               new CatalogBrand
               {
                   Id = 1,
                   Brand = "Brand 1",
               });

            modelBuilder.Entity<CatalogType>().HasData(
               new CatalogType
               {
                   Id = 1,
                   Type = "Type 1"
               });

            modelBuilder.Entity<CatalogItem>().HasData(
               new CatalogItem
               {
                   Id = 1,
                   Name = "Teste",
                   Description = "Description",
                   AvailableStock = 1,
                   MaxStockThreshold = 1,
                   OnReorder = false,
                   PictureFileName = "PictureFileName",
                   PictureUri = "PictureUri",
                   Price = 1.99m,
                   RestockThreshold = 1,
                   CatalogBrandId = 1,
                   CatalogTypeId = 1
               });
        }
    }
}
