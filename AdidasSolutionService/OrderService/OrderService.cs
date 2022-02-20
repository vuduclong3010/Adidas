using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class OrderService : IOrderService
    {
        private readonly AdidasDbContext _context;
        public OrderService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<OrdersPaging> GetListOrders(OrderPagingRequest request)
        {
            var res = new List<OrderViewModel>();
            var query = await _context.Orders.Where(x => x.Deleted == 0).ToListAsync();
            if(request.ShipPhoneNumber != null)
            {
                query = await _context.Orders.Where(x => x.ShipPhoneNumber == request.ShipPhoneNumber && x.Deleted == 0).ToListAsync();
            }
            res = query.Select(g => new OrderViewModel
            {
                Id = g.Id,
                OrderDate = g.OrderDate,
                ShipName = g.ShipName,
                ShipAddress = g.ShipAddress,
                ShipEmail = g.ShipEmail,
                ShipPhoneNumber = g.ShipPhoneNumber,
                Status = g.Status
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new OrdersPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }
    }
}
