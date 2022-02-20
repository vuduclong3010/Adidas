using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class PromotionService : IPromotionService
    {
        private readonly AdidasDbContext _context;
        public PromotionService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<PromotionViewModel> GetPromotionById(int Id)
        {
            var model = await _context.Promotions.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (model != null)
            {
                var newmodel = new PromotionViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    DiscountAmount = model.DiscountAmount,
                    Status = model.Status,
                };
                return newmodel;
            }
            return null;
        }

        public async Task<PromotionsPaging> GetListPromotions(PromotionPagingRequest request)
        {
            var res = new List<PromotionViewModel>();
            var query = await _context.Promotions.ToListAsync();
            res = query.Select(g => new PromotionViewModel
            {
                Id = g.Id,
                Name = g.Name,
                FromDate = g.FromDate,
                ToDate = g.ToDate,
                DiscountAmount = g.DiscountAmount,
                Status = g.Status,
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new PromotionsPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddPromotion(PromotionAddModel model)
        {
            if (model != null)
            {
                var newmdoel = new Promotion
                {
                    Name = model.Name,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    DiscountAmount = model.DiscountAmount,
                    Status = model.Status,
                };
                await _context.AddAsync(newmdoel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePromotion(PromotionUpdateModel model)
        {
            if (model != null)
            {
                var old = await _context.Promotions.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (old != null)
                {
                    old.Id = model.Id;
                    old.Name = model.Name;
                    old.FromDate = model.FromDate;
                    old.ToDate = model.ToDate;
                    old.DiscountAmount = model.DiscountAmount;
                    old.Status = model.Status;
                    _context.Promotions.Update(old);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeletePromotion(int Id)
        {
            var old = await _context.Promotions.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (old != null)
            {
                _context.Promotions.Remove(old);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
