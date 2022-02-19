using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService _service;
        public PromotionsController(IPromotionService service)
        {
            _service = service;
        }

        [HttpGet("GetListPromotions")]
        public async Task<PromotionsPaging> GetListPromotions([FromQuery] PromotionPagingRequest request)
        {
            return await _service.GetListPromotions(request);
        }

        [HttpGet("GetPromotionById")]
        public async Task<IActionResult> GetPromotionById(int Id)
        {
            var rs = await _service.GetPromotionById(Id);
            if(rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Supplier");
        }

        [HttpPost("AddPromotion")]
        public async Task<bool> AddPromotion(PromotionAddModel model)
        {
            return await _service.AddPromotion(model);
        }

        [HttpPost("UpdatePromotion")]
        public async Task<bool> UpdatePromotion(PromotionUpdateModel model)
        {
            return await _service.UpdatePromotion(model);
        }

        [HttpPost("DeletePromotion")]
        public async Task<bool> DeletePromotion(int Id)
        {
            return await _service.DeletePromotion(Id);
        }
    }
}
