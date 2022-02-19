using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface ISizeService
    {
        Task<SizesPaging> GetListSizes(SizePagingRequest request);
        Task<bool> AddSize(SizeAddModel model);
        Task<bool> UpdateSize(SizeUpdateModel model);
        Task<bool> DeleteSize(int Id);
        Task<SizeViewModel> GetSizeById(int Id);
    }
}
