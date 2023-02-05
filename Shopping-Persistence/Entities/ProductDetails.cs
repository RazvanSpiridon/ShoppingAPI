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
    [Table("ProductsDetails")]
    public class ProductDetails
    {
        public ProductDetails()
        {

        }

        [Key]
        public Guid ProductDetailsId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime LastUpdate { get; set; }

        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
