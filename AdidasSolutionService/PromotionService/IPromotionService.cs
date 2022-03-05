using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IPromotionService
    {
        Task<PromotionsPaging> GetListPromotions(PromotionPagingRequest request);
        Task<bool> AddPromotion(PromotionAddModel model);
        Task<bool> UpdatePromotion(PromotionUpdateModel model);
        Task<bool> DeletePromotion(int Id);
        Task<PromotionViewModel> GetPromotionById(int Id);
    }
}
