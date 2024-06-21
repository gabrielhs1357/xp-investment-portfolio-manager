using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

    public class ProductDto
    {
    }

    public class CreateProductDto
    {
    }

    public class ProductService : IProductService
    {
        public Task<Guid> AddAsync(CreateProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task DeactivateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(Guid id);
        Task DeactivateAsync(Guid id);
    }
}
