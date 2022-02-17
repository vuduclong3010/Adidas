using AdidasModels.Solution.DTO;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public interface ICategoryService
    {
        Task<CategoriesPaging> GetListCategories(CategoryPagingRequest categoryPagingRequest);
        Task<bool> AddCategory(CategoryAddModel model);
        Task<bool> UpdateCategory(CategoryUpdateModel model);
        Task<bool> DeleteCategory(int Id);
        Task<CategoryViewModel> GetCategoryById(int Id);
    }
}
