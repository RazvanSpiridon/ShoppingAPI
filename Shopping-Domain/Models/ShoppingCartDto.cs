using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping_Domain.Models
{
    public class ShoppingCartDto
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime LastUpdate { get; set; }

        public Profile? Profile { get; set; }
        public Product? Product { get; set; }

        public ShoppingCartDto(Guid shoppingCartId, Guid profileId, Guid productId, int productQuantity, DateTime lastUpdate, Profile profile, Product product)
        {
            ShoppingCartId = shoppingCartId;
            ProfileId = profileId;
            ProductId = productId;
            ProductQuantity = productQuantity;
            LastUpdate = lastUpdate;
            Profile = profile;
            Product = product;
        }
    }
}
