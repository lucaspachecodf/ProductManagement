using AutoGlass.ProductManagement.Application.DTOs;
using AutoGlass.ProductManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {   
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;            
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var result = _productAppService.CreateProduct(dto);

            return Ok(result);
        }
    }
}
