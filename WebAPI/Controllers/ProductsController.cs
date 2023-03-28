using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // is called as [ATTRIBUTE] in C# / [ANNOTATION] in Java
    public class ProductsController : Controller
    {
        // field'ın "_" ile verlmesi NAMİNG CONVENTİON olarak tanımlanan bir sabittir.
        // IoC Container -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService; // Injection
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Dependency chain
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);      // "Ok" gives us Status:200 code
            }

            return BadRequest(result); // "BadRequest" gives us Status:400 code

        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            // Dependency chain
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);      // "Ok" gives us Status:200 code
            }

            return BadRequest(result.Message); // "BadRequest" gives us Status:400 code

        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
