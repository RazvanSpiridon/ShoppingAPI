using Microsoft.AspNetCore.Mvc;
using Shopping_Business.Interface;
using Shopping_Domain.Models;
using Shopping_Persistence.Entities;

namespace ShoppingAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsDetailsController: ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;
        private readonly IProductService _productService;

        public ProductsDetailsController(IProductDetailsService productDetailsService, IProductService productService)
        {
            _productDetailsService = productDetailsService;
            _productService = productService;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<ProductDetailsDto>> GetProductDetails(Guid productId)
        {
            if (!await _productService.ProductExistsAsync(productId))
                return NotFound("The product does not exist");

            return Ok(await _productDetailsService.GetProductDetailsAsync(productId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetailsDto>> AddProductDetails(ProductDetailsDto productDetailsDto)
        {
            if (!await _productService.ProductExistsAsync(productDetailsDto.ProductId))
                return NotFound("The product does not exist");

            return Ok(await _productDetailsService.AddProductDetailsAsync(productDetailsDto));
        }

        [HttpPut]
        public async Task<ActionResult<ProductDetailsDto>> UpdateProductDetails(ProductDetailsDto productDetailsDto)
        {
            if (!await _productService.ProductExistsAsync(productDetailsDto.ProductId))
                return NotFound("The product does not exist");

            return Ok(await _productDetailsService.UpdateProductDetailsAsync(productDetailsDto));
        }
    }
}
