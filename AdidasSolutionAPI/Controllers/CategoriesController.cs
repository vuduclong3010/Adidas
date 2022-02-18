using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetListCategories")]
        public async Task<CategoriesPaging> GetListCategories([FromQuery]CategoryPagingRequest categoryPagingRequest)
        {
            var rs = await _categoryService.GetListCategories(categoryPagingRequest);
            return rs;
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var rs = await _categoryService.GetCategoryById(Id);
            if(rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Category");
        }

        [HttpPost("AddCategory")]
        public async Task<bool> AddCategory(CategoryAddModel model)
        {
            var rs = await _categoryService.AddCategory(model);
            return rs;
        }

        [HttpPost("UpdateCategory")]
        public async Task<bool> UpdateCategory(CategoryUpdateModel model)
        {
            var rs = await _categoryService.UpdateCategory(model);
            return rs;
        }

        [HttpPost("DeleteCategory")]
        public async Task<bool> DeleteCategory(int Id)
        {
            var rs = await _categoryService.DeleteCategory(Id);
            return rs;
        }
    }
}
