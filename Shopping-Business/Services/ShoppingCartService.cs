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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _dbContext;

        public ShoppingCartService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ShoppingCartDto> AddShopingCart(ShoppingCartDto shoppingCartDto)
        {
            var shoppingCart = new ShoppingCart
            {
                ShoppingCartId = new Guid(),
                ProfileId = shoppingCartDto.ProfileId,
                ProductId = shoppingCartDto.ProductId,
                ProductQuantity = shoppingCartDto.ProductQuantity,
                LastUpdate = DateTime.Now,
            };

            await _dbContext.ShoppingCarts.AddAsync(shoppingCart);
            await _dbContext.SaveChangesAsync();

            var profile = await _dbContext.Profiles
                .FirstOrDefaultAsync(p => p.ProfileId == shoppingCartDto.ProfileId) ?? new Profile();
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.ProductId== shoppingCartDto.ProductId) ?? new Product();

            return new ShoppingCartDto(
                shoppingCart.ShoppingCartId, 
                shoppingCart.ProfileId, 
                shoppingCart.ProductId, 
                shoppingCart.ProductQuantity,
                shoppingCart.LastUpdate, 
                profile, 
                product);
        }

        public async Task<ShoppingCartDto> DeleteShopingCart(Guid shoppingCartId)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
                .Where(p => p.ShoppingCartId== shoppingCartId)
                .Include(p => p.Profile)
                .Include(p => p.Product)
                .FirstOrDefaultAsync()?? new ShoppingCart();

            _dbContext.ShoppingCarts.Remove(shoppingCart);
            await _dbContext.SaveChangesAsync();

            return new ShoppingCartDto(
                shoppingCart.ShoppingCartId, 
                shoppingCart.ProfileId,
                shoppingCart.ProductId, 
                shoppingCart.ProductQuantity, 
                shoppingCart.LastUpdate, 
                shoppingCart.Profile, 
                shoppingCart.Product);

        }

        public async Task<List<ShoppingCartDto>> GetShoppingCarts()
        {
            var shoppingCarts = await _dbContext.ShoppingCarts.Include(p => p.Profile).Include(p=>p.Product).ToListAsync();

            return shoppingCarts.Select(s => new ShoppingCartDto(
                s.ShoppingCartId,
                s.ProfileId,
                s.ProductId,
                s.ProductQuantity,
                s.LastUpdate,
                s.Profile,
                s.Product
                )).ToList();
        }

        public async Task<ShoppingCartDto> GetShoppingCart(Guid shoppingCartId)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
                .Where(s => s.ShoppingCartId == shoppingCartId)
                .Include(p=>p.Profile)
                .Include(p=>p.Product)
                .FirstOrDefaultAsync() ?? new ShoppingCart();

            return new ShoppingCartDto(
                shoppingCart.ShoppingCartId,
                shoppingCart.ProfileId,
                shoppingCart.ProductId,
                shoppingCart.ProductQuantity,
                shoppingCart.LastUpdate,
                shoppingCart.Profile,
                shoppingCart.Product);
        }

        public async Task<ShoppingCartDto> UpdateShopingCart(Guid shoppingCartId, ShoppingCartDto shoppingCartDto)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
                .Where(s => s.ShoppingCartId == shoppingCartId)
                .Include(p => p.Profile)
                .Include(p => p.Product)
                .FirstOrDefaultAsync() ?? new ShoppingCart();

            shoppingCart.ProfileId = shoppingCartDto.ProfileId;
            shoppingCart.ProductId = shoppingCartDto.ProductId;
            shoppingCart.ProductQuantity = shoppingCartDto.ProductQuantity;
            shoppingCart.LastUpdate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return new ShoppingCartDto(
                shoppingCart.ShoppingCartId,
                shoppingCart.ProfileId,
                shoppingCart.ProductId,
                shoppingCart.ProductQuantity,
                shoppingCart.LastUpdate,
                shoppingCart.Profile,
                shoppingCart.Product);
        }

        public async Task<bool> ShoppingCartExists(Guid shoppingCartId)
        {
            return await _dbContext.ShoppingCarts.AnyAsync(s => s.ShoppingCartId == shoppingCartId);
        }
    }
}
