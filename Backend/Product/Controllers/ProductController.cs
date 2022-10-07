using ECommerceProductAPI.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProductAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpPost("new-product")]
        public async Task<IActionResult> CreateProduct(ProductDTO newProductDTO)
        {
            try {
                Product newProduct = await _productService.Create(newProductDTO);
                return Ok(newProduct);
            } 
            catch (Exception error){
                return BadRequest(error.Message);
            }
        }

        [HttpPost("update-product")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                Product newProduct = await _productService.Update(product);
                return Ok(newProduct);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("delete-product")]
        public async Task<ActionResult> DeleteProduct([FromQuery] int transactionId)
        {
            try
            {
                bool transaction = await _productService.Delete(transactionId);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("list-all-products")]
        public async Task<IActionResult> ListAllProducts()
        {
            try
            {
                List<Product> products = await _productService.ListAll();
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("list-products-by-category")]
        public async Task<IActionResult> ListByCategory([FromQuery] string category)
        {
            try
            {
                List<Product> products = await _productService.ListAll();
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}