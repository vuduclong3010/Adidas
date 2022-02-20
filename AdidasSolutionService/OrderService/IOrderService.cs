using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IOrderService
    {
        Task<OrdersPaging> GetListOrders(OrderPagingRequest request);
    }
}
