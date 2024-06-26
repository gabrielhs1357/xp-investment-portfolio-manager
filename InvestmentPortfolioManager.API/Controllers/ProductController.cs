using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


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

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (await _productService.CodeExists(productDto.Code))
            {
                return Conflict("Code already exists");
            }

            var productId = await _productService.AddAsync(productDto);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto productDto)
        {
            await _productService.UpdateAsync(id, productDto);
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
