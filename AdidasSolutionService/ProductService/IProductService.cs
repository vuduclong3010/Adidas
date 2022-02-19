using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface IProductService
    {
        Task<ProductsPaging> GetLisProducts(ProductPagingRequest productPagingRequest);
        Task<ProductViewModel> GetProductById(int Id);
        Task<bool> AddProduct(ProductAddModel model);
        Task<bool> UpdateProduct(ProductUpdateModel model);
        Task<bool> DeleteProduct(int Id);
    }
}
