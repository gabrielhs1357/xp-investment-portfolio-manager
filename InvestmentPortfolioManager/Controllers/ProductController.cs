using Microsoft.AspNetCore.Mvc;

using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;


namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            var productId = await _productService.AddAsync(productDto);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
        {
            await _productService.UpdateAsync(productDto);

            return NoContent();
        }

        [HttpPut("{id}/deactivate")]
        public async Task<ActionResult> DeactivateProduct(Guid id)
        {
            await _productService.DeactivateAsync(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }
}
