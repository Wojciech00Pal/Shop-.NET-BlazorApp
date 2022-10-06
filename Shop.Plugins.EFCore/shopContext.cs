using Microsoft.EntityFrameworkCore;
using Shop.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Plugins.EFCore
{
    public class shopContext:DbContext
    {

        public shopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductStorage> ProductStorage { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStorage>()
                .HasKey(x => new { x.StorageId});
            modelBuilder.Entity<Products>()
                .HasKey(x => new { x.ProductId });

            modelBuilder.Entity<ProductStorage>().HasData(
                new ProductStorage { StorageId=1, StorageQuantity=1000, Name="Apple",Price=5.5 },
                new ProductStorage { StorageId=2,StorageQuantity=1000,Name="Bread",Price=9},
                new ProductStorage { StorageId=3, StorageQuantity = 1000, Name = "Peach",Price=6 },
                new ProductStorage { StorageId=4, StorageQuantity = 1000, Name = "Tomatoes",Price=8}
                );
            modelBuilder.Entity<Products>();
            
     
        }


        }
}
