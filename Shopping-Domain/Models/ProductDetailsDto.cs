using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping_Domain.Models
{
    public class ProductDetailsDto
    {
        public ProductDetailsDto(Guid productDetailsId, string description, DateTime lastUpdate, Guid productId, Product? product)
        {
            ProductDetailsId = productDetailsId;
            Description = description;
            LastUpdate = lastUpdate;
            ProductId = productId;
            Product = product;
        } 

        public Guid ProductDetailsId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime LastUpdate { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        
    }
}
