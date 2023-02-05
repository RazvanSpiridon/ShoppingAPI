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
    [Table("ShoppingCarts")]
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(Guid shoppingCartId, Guid profileId, Guid productId, int productQuantity, DateTime lastUpdate)
        {
            ShoppingCartId = shoppingCartId;
            ProfileId = profileId;
            ProductId = productId;
            ProductQuantity = productQuantity;
            LastUpdate = lastUpdate;
        }

        [Key]
        public Guid ShoppingCartId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public Profile Profile { get; set; } = null!;
        [JsonIgnore]
        public Product Product { get; set; }  = null!;


    }
}
