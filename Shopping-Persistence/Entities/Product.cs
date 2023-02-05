using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping_Persistence.Entities
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {

        }
        public Product(Guid productId, string name, int price, bool isAvailable, DateTime lastUpdate)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            LastUpdate = lastUpdate;
            
        }

        [Key]
        public Guid ProductId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int Price { get; set; } 
        public bool IsAvailable { get; set; }
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
        [JsonIgnore]
        public ProductDetails? ProductDetails { get; set; }

        
    }
}
