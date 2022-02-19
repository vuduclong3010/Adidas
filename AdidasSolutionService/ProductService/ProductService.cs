using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class ProductService : IProductService
    {
        private readonly AdidasDbContext _context;
        public ProductService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsPaging> GetLisProducts(ProductPagingRequest productPagingRequest)
        {
            var res = new List<ProductViewModel>();
            var query = await _context.Products.ToListAsync();
            res = query.Select(g => new ProductViewModel
            {
                Id = g.Id,
                Price = g.Price,
                OriginalPrice = g.OriginalPrice,
                ViewCount = g.ViewCount,
                IsFeatured = g.IsFeatured,
                DateCreated = g.DateCreated,
                SizeName = _context.Sizes.Where(x => x.Id == g.SizeId).FirstOrDefault().Name,
                SupplierName = _context.Suppliers.Where(x => x.Id == g.SupplierId).FirstOrDefault().Name,
                TrademarkName = _context.Trademarks.Where(x => x.Id == g.TrademarkId).FirstOrDefault().Name,
                PromotionName = _context.Promotions.Where(x => x.Id == g.PromotionId).FirstOrDefault() == null ? null : (_context.Promotions.Where(x => x.Id == g.PromotionId).FirstOrDefault().Name),
                ProductName = g.ProductName,
                Color = g.Color,
                SeoTitle = g.SeoTitle,
                Description = g.Description,
                Material = g.Material,
                shoelace = g.shoelace,
                DeGiay = g.DeGiay,
                TrongLuong = g.TrongLuong,
                KieuDang = g.KieuDang
            }).Skip(productPagingRequest.PageSize * (productPagingRequest.PageIndex - 1))
                               .Take(productPagingRequest.PageSize).ToList();
            var totalItem = query.Count();
            return new ProductsPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<ProductViewModel> GetProductById(int Id)
        {
            var ProductById = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ProductById != null)
            {
                var newProduct = new ProductViewModel
                {
                    Id = ProductById.Id,
                    Price = ProductById.Price,
                    OriginalPrice = ProductById.OriginalPrice,
                    ViewCount = ProductById.ViewCount,
                    IsFeatured = ProductById.IsFeatured,
                    DateCreated = ProductById.DateCreated,
                    SizeName = _context.Sizes.Where(x => x.Id == ProductById.SizeId).FirstOrDefault().Name,
                    SupplierName = _context.Suppliers.Where(x => x.Id == ProductById.SupplierId).FirstOrDefault().Name,
                    TrademarkName = _context.Trademarks.Where(x => x.Id == ProductById.TrademarkId).FirstOrDefault().Name,
                    PromotionName = _context.Promotions.Where(x => x.Id == ProductById.PromotionId).FirstOrDefault() == null ? null : (_context.Promotions.Where(x => x.Id == ProductById.PromotionId).FirstOrDefault().Name),
                    ProductName = ProductById.ProductName,
                    Color = ProductById.Color,
                    SeoTitle = ProductById.SeoTitle,
                    Description = ProductById.Description,
                    Material = ProductById.Material,
                    shoelace = ProductById.shoelace,
                    DeGiay = ProductById.DeGiay,
                    TrongLuong = ProductById.TrongLuong,
                    KieuDang = ProductById.KieuDang
                };
                return newProduct;
            }
            return null;
        }

        public async Task<bool> AddProduct(ProductAddModel model)
        {
            if (model != null)
            {
                var newProduct = new Product
                {
                    Price = model.Price,
                    OriginalPrice = model.OriginalPrice,
                    ViewCount = model.ViewCount,
                    IsFeatured = true,
                    DateCreated = DateTime.Now,
                    SizeId = model.SizeId,
                    SupplierId = model.SupplierId,
                    TrademarkId = model.TrademarkId,
                    PromotionId = model.PromotionId,
                    ProductName = model.ProductName,
                    Color = model.Color,
                    SeoTitle = model.SeoTitle,
                    Description = model.Description,
                    Material = model.Material,
                    shoelace = model.shoelace,
                    DeGiay = model.DeGiay,
                    TrongLuong = model.TrongLuong,
                    KieuDang = model.KieuDang
                };
                _context.Products.Add(newProduct);
                //if (model.Categories != null)
                //{
                //    foreach (var category in model.Categories)
                //    {
                //        var newProductInCategory = new ProductInCategory
                //        {
                //            CategoryId = category.CategoryId,
                //            ProductId = newProduct.Id
                //        };
                //        _context.ProductInCategories.Add(newProductInCategory);
                //    }
                //}
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<bool> UpdateProduct(ProductUpdateModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProduct(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
