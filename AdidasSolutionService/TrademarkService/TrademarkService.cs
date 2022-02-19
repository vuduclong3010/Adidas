using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
﻿using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class TrademarkService : ITrademarkService
    {
        private readonly AdidasDbContext _context;
        public TrademarkService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<TrademarkViewModel> GetTrademarkById(int Id)
        {
            var rs = await _context.Trademarks.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (rs != null)
            {
                var newrs = new TrademarkViewModel
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    Despripation =  rs.Despripation
                };
                return newrs;
            }
            return null;
        }

        public async Task<TrademarkrsPaging> GetListTrademarks(TrademarkPagingRequest request)
        {
            var res = new List<TrademarkViewModel>();
            var query = await _context.Trademarks.ToListAsync();
            res = query.Select(g => new TrademarkViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Despripation =  g.Despripation
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new TrademarkrsPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddTrademark(TrademarkAddModel model)
        {
            if (model != null)
            {
                var newmodel = new Trademark
                {
                    Name = model.Name,
                    Despripation = model.Despripation
                };
                await _context.AddAsync(newmodel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateTrademark(TrademarkUpdateModel model)
        {
            if (model != null)
            {
                var old = await _context.Trademarks.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (old != null)
                {
                    old.Id = model.Id;
                    old.Name = model.Name;
                    old.Despripation = model.Despripation;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTrademark(int Id)
        {
            var old = await _context.Trademarks.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (old != null)
            {
                _context.Trademarks.Remove(old);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
