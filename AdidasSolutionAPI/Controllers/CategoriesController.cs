using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;

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
    }
}
