using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductFilterAppService _productFilterAppService;

        public ProductController(IProductAppService productAppService, IProductFilterAppService productFilterAppService)
        {
            _productAppService = productAppService;
            _productFilterAppService = productFilterAppService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct(CreateProductDto productDto)
        {
            var result = _productAppService.CreateProduct(productDto);

            if (result.ProductId == 0 || result.Errors != null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("Filter")]
        public IActionResult Filter(ProductFilterDto productFilterDto)
        {
            var result = _productFilterAppService.GetFilteredProducts(productFilterDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _productAppService.GetById(id);

            return Ok(result);
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(ProductDto productDto)
        {
            var result = _productAppService.Update(productDto);

            if (result.Errors != null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _productAppService.Delete(id);

            if (result)
                return Ok(result);

            return BadRequest("Houve um problema ao excluir o produto");
        }
    }
}
