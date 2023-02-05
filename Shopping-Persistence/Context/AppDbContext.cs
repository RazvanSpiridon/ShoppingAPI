using Microsoft.EntityFrameworkCore;
using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductDetails> ProductsDetails { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(p => p.Product)
                .WithMany(s => s.ShoppingCarts)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(p => p.Profile)
                .WithMany(s => s.ShoppingCarts)
                .HasForeignKey(p => p.ProfileId);

            modelBuilder.Entity<ProductDetails>()
                .HasOne(d => d.Product)
                .WithOne(p => p.ProductDetails)
                .HasForeignKey<ProductDetails>(p => p.ProductId);

        }
    }
}
