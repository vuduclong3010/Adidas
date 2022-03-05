using AdidasModels.Solution;
using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IOrderService
    {
        Task<OrdersPaging> GetListOrders(OrderPagingRequest request);
        Task<IApiResult> SendMail(SendMailViewModel model);
    }
}
