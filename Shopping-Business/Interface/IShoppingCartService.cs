using Shopping_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Interface
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCartDto>> GetShoppingCarts();
        Task<ShoppingCartDto> GetShoppingCart(Guid shoppingCartId);
        //Task<ShoppingCartDto> GetProfilesWithShoppingCart();
        //Task<ShoppingCartDto> GetProfileWithShoppingCart(Guid profileId);
        Task<ShoppingCartDto> AddShopingCart(ShoppingCartDto shoppingCart);
        Task<ShoppingCartDto> UpdateShopingCart(Guid shoppingCartId, ShoppingCartDto shoppingCartDto);
        Task<ShoppingCartDto> DeleteShopingCart(Guid shoppingCartId);
        Task<bool> ShoppingCartExists(Guid shoppingCartId);
    }
}
