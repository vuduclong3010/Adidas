using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IContactService
    {
        Task<ContactsPaging> GetListContacts(ContactPagingRequest ContactPagingRequest);
        Task<bool> AddContact(ContactAddModel model);
        Task<bool> UpdateContact(ContactUpdateModel model);
        Task<bool> DeleteContact(int Id);
        Task<ContactViewModel> GetContactById(int Id);
    }
}
