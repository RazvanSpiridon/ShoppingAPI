using Shopping_Domain.Models;
using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Interface
{
    public interface IProductService
    {
        Task<bool> ProductExistsAsync(Guid productId);
        Task<List<ProductDto>> GetProductsActiveAsync();
        Task<List<ProductDto>> GetProductsDisableAsync();
        Task<ProductDto> GetProductAsync(Guid productId);
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto productDto);
        Task<ProductDto> UpdateStatusProduct(Guid productId, bool status);
        Task<ProductDto> DeleteProduct(Guid productId);
        Task<bool> ProductIsActive(Guid productId);
    }
}
