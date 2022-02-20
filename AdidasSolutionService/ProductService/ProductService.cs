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
                _context.SaveChanges();
                if (model.Categories.Count > 0)
                {
                    foreach (var category in model.Categories)
                    {
                        var newProductInCategory = new ProductInCategory
                        {
                            CategoryId = category.CategoryId,
                            ProductId = newProduct.Id
                        };
                        _context.ProductInCategories.Add(newProductInCategory);
                    }
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProduct(ProductUpdateModel model)
        {
            if (model != null)
            {
                var oldProduct = await _context.Products.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (oldProduct != null)
                {
                    oldProduct.Id = oldProduct.Id;
                    oldProduct.Price = oldProduct.Price;
                    oldProduct.OriginalPrice = oldProduct.OriginalPrice;
                    oldProduct.ViewCount = oldProduct.ViewCount;
                    oldProduct.IsFeatured = oldProduct.IsFeatured;
                    oldProduct.DateCreated = oldProduct.DateCreated;
                    oldProduct.SizeId = model.SizeId;
                    oldProduct.SupplierId = model.SupplierId;
                    oldProduct.TrademarkId = model.TrademarkId;
                    oldProduct.PromotionId = oldProduct.PromotionId;
                    oldProduct.ProductName = model.ProductName;
                    oldProduct.Color = model.Color;
                    oldProduct.SeoTitle = model.SeoTitle;
                    oldProduct.Description = model.Description;
                    oldProduct.Material = model.Material;
                    oldProduct.shoelace = model.shoelace;
                    oldProduct.DeGiay = model.DeGiay;
                    oldProduct.TrongLuong = model.TrongLuong;
                    oldProduct.KieuDang = model.KieuDang;
                }
                _context.Products.Update(oldProduct);
                _context.SaveChanges();

                if(model.Categories.Count > 0)
                {
                    var oldProductInCategory = await _context.ProductInCategories.Where(x => x.ProductId == oldProduct.Id).ToListAsync();
                    foreach (var item in oldProductInCategory)
                    {
                        _context.Remove(item);
                        _context.SaveChanges();
                    }
                    foreach (var category in model.Categories)
                    {
                        var newProductInCategory = new ProductInCategory
                        {
                            CategoryId = category.CategoryId,
                            ProductId = oldProduct.Id
                        };
                        _context.ProductInCategories.Add(newProductInCategory);
                    }
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var oldProduct = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (oldProduct != null)
            {
                var oldProductInCategory = await _context.ProductInCategories.Where(x => x.ProductId == oldProduct.Id).ToListAsync();
                _context.RemoveRange(oldProductInCategory);
                _context.Products.Remove(oldProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePrice(UpdatePriceModel model)
        {
            if(model.Price.CompareTo(0) != 0)
            {
                var oldProduct = await _context.Products.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if(oldProduct != null)
                {
                    oldProduct.Price = model.Price;
                    _context.Products.Update(oldProduct);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateViewCount(int Id, int ViewCount)
        {
            if (ViewCount > 0)
            {
                var oldProduct = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (oldProduct != null)
                {
                    oldProduct.ViewCount = ViewCount;
                    _context.Products.Update(oldProduct);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdatePromotion(int Id, int PromotionId)
        {
            if (PromotionId > 0)
            {
                var oldProduct = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (oldProduct != null)
                {
                    oldProduct.PromotionId = PromotionId;
                    _context.Products.Update(oldProduct);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
