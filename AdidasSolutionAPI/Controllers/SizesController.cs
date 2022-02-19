using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _service;
        public SizesController(ISizeService service)
        {
            _service = service;
        }

        [HttpGet("GetListSizes")]
        public async Task<SizesPaging> GetListSizes([FromQuery] SizePagingRequest request)
        {
            return await _service.GetListSizes(request);
        }

        [HttpGet("GetSizeById")]
        public async Task<IActionResult> GetSizeById(int Id)
        {
            var rs = await _service.GetSizeById(Id);
            if(rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Supplier");
        }

        [HttpPost("AddSize")]
        public async Task<bool> AddSize(SizeAddModel model)
        {
            return await _service.AddSize(model);
        }

        [HttpPost("UpdateSize")]
        public async Task<bool> UpdateSize(SizeUpdateModel model)
        {
            return await _service.UpdateSize(model);
        }

        [HttpPost("DeleteSize")]
        public async Task<bool> DeleteSize(int Id)
        {
            return await _service.DeleteSize(Id);
        }
    }
}
