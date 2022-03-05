using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IUserService
    {
        Task<UsersPaging> GetListUers(UserPagingRequest request);
        Task<int> LoginUser(LoginUserViewModel request);
        Task<bool> UpdateStatus(UserAddStatusModel model);
    }
}
