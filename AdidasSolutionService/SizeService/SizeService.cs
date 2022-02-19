using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
﻿using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class SizeService : ISizeService
    {
        private readonly AdidasDbContext _context;
        public SizeService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<SizeViewModel> GetSizeById(int Id)
        {
            var model = await _context.Sizes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (model != null)
            {
                var newmodel = new SizeViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Detail = model.Detail,
                    SizeDes = model.SizeDes
                };
                return newmodel;
            }
            return null;
        }

        public async Task<SizesPaging> GetListSizes(SizePagingRequest request)
        {
            var res = new List<SizeViewModel>();
            var query = await _context.Sizes.ToListAsync();
            res = query.Select(g => new SizeViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Detail = g.Detail,
                SizeDes= g.SizeDes
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new SizesPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddSize(SizeAddModel model)
        {
            if (model != null)
            {
                var newmdoel = new Size
                {
                    Name = model.Name,
                    Detail = model.Detail,
                    SizeDes = model.SizeDes
                };
                await _context.AddAsync(newmdoel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSize(SizeUpdateModel model)
        {
            if (model != null)
            {
                var old = await _context.Sizes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (old != null)
                {
                    old.Id = model.Id;
                    old.Name = model.Name;
                    old.SizeDes = model.SizeDes;
                    old.Detail = model.Detail;
                    _context.Sizes.Update(old);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSize(int Id)
        {
            var old = await _context.Sizes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (old != null)
            {
                _context.Sizes.Remove(old);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
