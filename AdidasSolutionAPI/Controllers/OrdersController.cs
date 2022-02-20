using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetListCategories")]
        public async Task<OrdersPaging> GetListCategories([FromQuery] OrderPagingRequest categoryPagingRequest)
        {
            var rs = await _orderService.GetListOrders(categoryPagingRequest);
            return rs;
        }
    }
}
