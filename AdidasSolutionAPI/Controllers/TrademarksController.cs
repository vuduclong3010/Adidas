using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrademarksController : ControllerBase
    {
        private readonly ITrademarkService _service;
        public TrademarksController(ITrademarkService service)
        {
            _service = service;
        }

        [HttpGet("GetListTrademarks")]
        public async Task<TrademarkrsPaging> GetListTrademarks([FromQuery] TrademarkPagingRequest request)
        {
            return await _service.GetListTrademarks(request);
        }

        [HttpGet("GetTrademarkById")]
        public async Task<IActionResult> GetTrademarkById(int Id)
        {
            var rs = await _service.GetTrademarkById(Id);
            if(rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Supplier");
        }

        [HttpPost("AddTrademark")]
        public async Task<bool> AddTrademark(TrademarkAddModel model)
        {
            return await _service.AddTrademark(model);
        }

        [HttpPost("UpdateTrademark")]
        public async Task<bool> UpdateTrademark(TrademarkUpdateModel model)
        {
            return await _service.UpdateTrademark(model);
        }

        [HttpPost("DeleteTrademark")]
        public async Task<bool> DeleteTrademark(int Id)
        {
            return await _service.DeleteTrademark(Id);
        }
    }
}
