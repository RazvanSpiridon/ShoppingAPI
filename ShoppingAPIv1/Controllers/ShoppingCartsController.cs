using Microsoft.AspNetCore.Mvc;
using Shopping_Business.Interface;
using Shopping_Domain.Models;
using Shopping_Persistence.Entities;

namespace ShoppingAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;
        private readonly IProfileService _profileService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService, IProductService productService, IProfileService profileService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingCartDto>>> GetShoppingCarts()
        {
            return Ok(await _shoppingCartService.GetShoppingCarts());
        }

        [HttpGet]
        [Route("{shoppingCartId}")]
        public async Task<ActionResult<ShoppingCartDto>> GetShoppingCart(Guid shoppingCartId)
        {
            if (!await _shoppingCartService.ShoppingCartExists(shoppingCartId))
                return NotFound();

            return Ok(await _shoppingCartService.GetShoppingCart(shoppingCartId));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDto>> AddShoppingCart(ShoppingCartDto shoppingCartDto)
        {
            if (!await _profileService.ProfileExistsAsync(shoppingCartDto.ProfileId))
                return NotFound($"The profile with id {shoppingCartDto.ProfileId} does not exist!");
            if (!await _productService.ProductExistsAsync(shoppingCartDto.ProductId))
                return NotFound($"The product with id {shoppingCartDto.ProductId} does not exist");
            if (!await _productService.ProductIsActive(shoppingCartDto.ProductId))
                return BadRequest($"The product with id {shoppingCartDto.ProductId} is not active");

            return Ok(await _shoppingCartService.AddShopingCart(shoppingCartDto));
        }

        [HttpPut]
        [Route("{shoppingCartId}")]
        public async Task<ActionResult<ShoppingCartDto>> UpdateSchoppingCart(Guid shoppingCartId, ShoppingCartDto shoppingCartDto)
        {
            if (!await _shoppingCartService.ShoppingCartExists(shoppingCartId))
                return NotFound();

            return Ok(await _shoppingCartService.UpdateShopingCart(shoppingCartId, shoppingCartDto));
        }

        [HttpDelete]
        [Route("{shoppingCartId}")]
        public async Task<ActionResult<ShoppingCartDto>> DeleteShoppingCart(Guid shoppingCartId)
        {
            if (!await _shoppingCartService.ShoppingCartExists(shoppingCartId))
                return NotFound();

            return Ok(await _shoppingCartService.DeleteShopingCart(shoppingCartId));
        }
    }
}
