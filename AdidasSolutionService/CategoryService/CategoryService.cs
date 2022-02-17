using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using AdidasModels.Solution.Entitys;
using AdidasModels.Solution.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class CategoryService : ICategoryService
    {
        private readonly AdidasDbContext _context;
        public CategoryService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryViewModel> GetCategoryById(int Id)
        {
            var CategoryById = await _context.Categories.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(CategoryById != null)
            {
                var newCategory = new CategoryViewModel
                {
                    Id = CategoryById.Id,
                    Name = CategoryById.Name,
                    SeoDescription = CategoryById.SeoDescription,
                    SeoAlias = CategoryById.SeoAlias,
                    SeoTitle = CategoryById.SeoTitle,
                    SortOrder = CategoryById.SortOrder,
                    IsShowOnHome = CategoryById.IsShowOnHome
                };
                return newCategory;
            }
            return null;
        }

        public async Task<CategoriesPaging> GetListCategories(CategoryPagingRequest categoryPagingRequest)
        {
            var res = new List<CategoryViewModel>();
            var query = await _context.Categories.ToListAsync();
            res = query.Select(g => new CategoryViewModel
            {
                Id = g.Id,
                Name = g.Name,
                SeoDescription = g.SeoDescription,
                SeoAlias = g.SeoAlias,
                SeoTitle = g.SeoTitle,
                IsShowOnHome = g.IsShowOnHome,
                SortOrder = g.SortOrder
            }).Skip(categoryPagingRequest.PageSize * (categoryPagingRequest.PageIndex - 1))
                               .Take(categoryPagingRequest.PageSize).ToList();
            var totalItem = query.Count();
            return new CategoriesPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddCategory(CategoryAddModel model)
        {
            if (model != null)
            {
                var newCategory = new Category
                {
                    Name = model.Name,
                    SeoDescription = model.SeoDescription,
                    SeoTitle = model.SeoTitle,
                    SeoAlias = model.SeoAlias,
                    SortOrder = model.SortOrder,
                    IsShowOnHome = Status.Active,
                };
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(CategoryUpdateModel model)
        {
            if (model != null)
            {
                var oldCategory = await _context.Categories.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (oldCategory != null)
                {
                    oldCategory.Id = model.Id;
                    oldCategory.Name = model.Name;
                    oldCategory.SeoDescription = model.SeoDescription;
                    oldCategory.SeoTitle = model.SeoTitle;
                    oldCategory.SortOrder = model.SortOrder;
                    oldCategory.SeoAlias = model.SeoAlias;
                    oldCategory.IsShowOnHome = model.IsShowOnHome;
                    _context.Categories.Update(oldCategory);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int Id)
        {
            var oldCategory = await _context.Categories.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (oldCategory != null)
            {
                var oldProductInCategories = await _context.ProductInCategories.Where(x => x.CategoryId == oldCategory.Id).ToListAsync();
                if(oldProductInCategories.Count > 0)
                {
                    foreach (var item in oldProductInCategories)
                    {
                        _context.ProductInCategories.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                _context.Categories.Remove(oldCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
