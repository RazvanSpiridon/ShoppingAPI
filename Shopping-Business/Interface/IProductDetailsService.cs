using Shopping_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Interface
{
    public interface IProductDetailsService 
    {
        Task<ProductDetailsDto> GetProductDetailsAsync(Guid productId);
        Task<ProductDetailsDto> AddProductDetailsAsync(ProductDetailsDto productDetailsDto);
        Task<ProductDetailsDto> UpdateProductDetailsAsync(ProductDetailsDto productDetailsDto);
    }
}
