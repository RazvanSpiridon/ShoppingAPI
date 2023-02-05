using Microsoft.AspNetCore.Mvc;
using Shopping_Business.Interface;
using Shopping_Domain.Models;
using Shopping_Persistence.Entities;

namespace ShoppingAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsActive()
        {
            return Ok(await _productService.GetProductsActiveAsync());
        }

        [HttpGet]
        [Route("disableProducts")]
        public async Task<ActionResult<List<Product>>> GetProductsDisable()
        {
            return Ok(await _productService.GetProductsDisableAsync());
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid productId)
        {
            if (!await _productService.ProductExistsAsync(productId))
                return NotFound("The product does not exist");

            return Ok(await _productService.GetProductAsync(productId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto productDto)
        {
            return Ok(await _productService.AddProductAsync(productDto));
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(Guid productId, ProductDto productDto)
        {
            if (!await _productService.ProductExistsAsync(productId))
                return NotFound("The product does not exist");

            return Ok(await _productService.UpdateProductAsync(productId, productDto));
        }

        [HttpPut]
        [Route("changeStatus/{productId}")]
        public async Task<ActionResult<ProductDto>> UpdateStatusProduct(Guid productId, bool status)
        {
            if (!await _productService.ProductExistsAsync(productId))
                return NotFound("The product does not exist");

            var product = await _productService.GetProductAsync(productId);
            if (product.IsAvailable == status)
                return BadRequest($"status of product is already {status}");

            return Ok(await _productService.UpdateStatusProduct(productId, status));
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(Guid productId)
        {
            if (!await _productService.ProductExistsAsync(productId))
                return NotFound("The product does not exist");

            return Ok(await _productService.DeleteProduct(productId));
        }
    }
}
