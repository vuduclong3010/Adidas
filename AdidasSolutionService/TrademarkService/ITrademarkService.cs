using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface ITrademarkService
    {
        Task<TrademarkrsPaging> GetListTrademarks(TrademarkPagingRequest request);
        Task<bool> AddTrademark(TrademarkAddModel model);
        Task<bool> UpdateTrademark(TrademarkUpdateModel model);
        Task<bool> DeleteTrademark(int Id);
        Task<TrademarkViewModel> GetTrademarkById(int Id);
    }
}
