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
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                ProductId = new Guid(),
                Name = productDto.Name,
                Price = productDto.Price,
                IsAvailable = true,
                LastUpdate = DateTime.Now,
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return new ProductDto(product.ProductId, product.Name, product.Price, product.IsAvailable, product.LastUpdate);
        }

        public async Task<ProductDto> DeleteProduct(Guid productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId) ?? new Product();

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return new ProductDto(product.ProductId, product.Name, product.Price, product.IsAvailable, product.LastUpdate);

        }

        public async Task<ProductDto> GetProductAsync(Guid productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId) ?? new Product();

            return new ProductDto(product.ProductId, product.Name, product.Price, product.IsAvailable, product.LastUpdate);
        }

        public async Task<List<ProductDto>> GetProductsActiveAsync()
        {
            var productsActive = await _dbContext.Products.Where(p => p.IsAvailable == true).ToListAsync();

            return productsActive.Select(p => new ProductDto(
                p.ProductId,
                p.Name,
                p.Price,
                p.IsAvailable,
                p.LastUpdate
                )).ToList();
        }

        public async Task<List<ProductDto>> GetProductsDisableAsync()
        {
            var productsActive = await _dbContext.Products.Where(p => p.IsAvailable == false).ToListAsync();

            return productsActive.Select(p => new ProductDto(
                p.ProductId,
                p.Name,
                p.Price,
                p.IsAvailable,
                p.LastUpdate
                )).ToList();
        }

        public async Task<bool> ProductExistsAsync(Guid productId)
        {
            return await _dbContext.Products.AnyAsync(x => x.ProductId == productId);
        }

        public async Task<bool> ProductIsActive(Guid productId)
        {
            return await _dbContext.Products.AnyAsync(x => x.ProductId == productId && x.IsAvailable == true);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto productDto)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId) ?? new Product();
            product.ProductId = productId;
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.IsAvailable = productDto.IsAvailable;
            product.LastUpdate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return new ProductDto(product.ProductId, product.Name, product.Price, product.IsAvailable, product.LastUpdate);

        }

        public async Task<ProductDto> UpdateStatusProduct(Guid productId, bool status)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId) ?? new Product();

            product.IsAvailable = status;

            await _dbContext.SaveChangesAsync();

            return new ProductDto(product.ProductId, product.Name, product.Price, product.IsAvailable, product.LastUpdate);
        }
    }
}
