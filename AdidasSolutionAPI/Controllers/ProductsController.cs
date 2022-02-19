using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetListProducts")]
        public async Task<ProductsPaging> GetListSuppliers([FromQuery] ProductPagingRequest productPagingRequest)
        {
            return await _productService.GetLisProducts(productPagingRequest);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var rs = await _productService.GetProductById(Id);
            if (rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Product");
        }

        [HttpPost("AddProduct")]
        public async Task<bool> AddProduct(ProductAddModel model)
        {
            var rs = await _productService.AddProduct(model);
            return rs;
        }
    }
}
