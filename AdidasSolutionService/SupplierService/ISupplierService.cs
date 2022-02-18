using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface ISupplierService
    {
        Task<SuppliersPaging> GetListSuppliers(SupplierPagingRequest supplierPagingRequest);
        Task<bool> AddSupplier(SupplierAddModel model);
        Task<bool> UpdateSupplier(SupplierUpdateModel model);
        Task<bool> DeleteSupplier(int Id);
        Task<SupplierViewModel> GetSupplierById(int Id);
    }
}
