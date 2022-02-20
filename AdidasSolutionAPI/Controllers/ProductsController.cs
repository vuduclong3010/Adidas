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
        public async Task<bool> AddProduct([FromForm] ProductAddModel model)
        {
            var rs = await _productService.AddProduct(model);
            return rs;
        }

        [HttpPost("UpdateProduct")]
        public async Task<bool> UpdateProduct(ProductUpdateModel model)
        {
            return await _productService.UpdateProduct(model);
        }

        [HttpPost("DeleteProduct")]
        public async Task<bool> DeleteProduct(int Id)
        {
            return await _productService.DeleteProduct(Id);
        }

        [HttpPost("UpdatePriceProduct")]
        public async Task<bool> UpdatePriceProduct(UpdatePriceModel model)
        {
            return await _productService.UpdatePrice(model);
        }

        [HttpPost("UpdateViewCount")]
        public async Task<bool> UpdateViewCount(int Id, int ViewCount)
        {
            return await _productService.UpdateViewCount(Id, ViewCount);
        }

        [HttpPost("UpdatePromotion")]
        public async Task<bool> UpdatePromotion(int Id, int PromotionId)
        {
            return await _productService.UpdatePromotion(Id, PromotionId);
        }
    }
}
