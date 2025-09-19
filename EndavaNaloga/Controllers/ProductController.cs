using EndavaNaloga.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EndavaNaloga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("filter")]
        public IActionResult GetFilteredProducts([FromQuery] string? name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? categoryName)
        {
            try
            {
                var products = _productRepository.GetFilteredList(name, minPrice, maxPrice, categoryName);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("filter/name/{name}")]
        public IActionResult GetFilteredProductsByName(string name)
        {
            try
            {
                var products = _productRepository.GetFilteredList(name, null, null, null);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("filter/minPrice/{price}")]
        public IActionResult GetFilteredProductsByMinPrice(decimal price)
        {
            try
            {
                var products = _productRepository.GetFilteredList(null, price, null, null);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("filter/maxPrice/{price}")]
        public IActionResult GetFilteredProductsByMaxPrice(decimal price)
        {
            try
            {
                var products = _productRepository.GetFilteredList(null, null, price, null);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("filter/category/{categoryName}")]
        public IActionResult GetFilteredProductsByCategory(string categoryName)
        {
            try
            {
                var products = _productRepository.GetFilteredList(null, null, null, categoryName);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with id {id} not found.");
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] Models.Product product)
        {
            try
            {
                if(product == null)
                {
                    return BadRequest("Product is missing");
                }
                if(string.IsNullOrEmpty(product.Name) || product.Price < 0)
                {
                    return BadRequest("Product has invalid data");
                }
                var updatedProduct = _productRepository.UpdateProduct(id, product);
                if (updatedProduct == null)
                {
                    return NotFound($"Product with id {id} not found.");
                }
                return Ok(updatedProduct);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
