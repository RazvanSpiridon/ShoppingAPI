using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Domain.Models
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime LastUpdate { get; set; }

        public ProductDto(Guid productId, string name, int price, bool isAvailable, DateTime lastUpdate)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            LastUpdate = lastUpdate;
        }
    }
}
