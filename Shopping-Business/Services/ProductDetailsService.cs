using Microsoft.EntityFrameworkCore;
using Shopping_Business.Interface;
using Shopping_Domain.Models;
using Shopping_Persistence.Context;
using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Services
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly AppDbContext _dbContext;

        public ProductDetailsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDetailsDto> AddProductDetailsAsync(ProductDetailsDto productDetailsDto)
        {
            var productDetails = new ProductDetails
            {
                ProductDetailsId = new Guid(),
                Description = productDetailsDto.Description,
                LastUpdate = DateTime.Now,
                ProductId = productDetailsDto.ProductId,
            };

            await _dbContext.ProductsDetails.AddAsync(productDetails);
            await _dbContext.SaveChangesAsync();

            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId== productDetailsDto.ProductId);

            return new ProductDetailsDto(productDetails.ProductDetailsId, productDetails.Description, productDetails.LastUpdate, productDetails.ProductId, product);

        }


        public async Task<ProductDetailsDto> GetProductDetailsAsync(Guid productId)
        {
            var productDetails = await _dbContext.ProductsDetails
                .Where(x => x.ProductId == productId)
                .Include(p => p.Product)
                .FirstOrDefaultAsync() ?? new ProductDetails();

            return new ProductDetailsDto(productDetails.ProductDetailsId, productDetails.Description, productDetails.LastUpdate, productDetails.ProductId, productDetails.Product);
        }

        public async Task<ProductDetailsDto> UpdateProductDetailsAsync(ProductDetailsDto productDetailsDto)
        {
            var productDetails = await _dbContext.ProductsDetails
                .Where(p => p.ProductId == productDetailsDto.ProductId)
                .Include(p => p.Product)
                .FirstOrDefaultAsync() ?? new ProductDetails();

            productDetails.Description = productDetailsDto.Description;
            productDetails.LastUpdate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return new ProductDetailsDto(productDetails.ProductDetailsId, productDetails.Description, productDetails.LastUpdate, productDetails.ProductId, productDetails.Product);

        }
    }
}
