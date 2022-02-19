using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
﻿using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class SupplierService : ISupplierService
    {
        private readonly AdidasDbContext _context;
        public SupplierService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierViewModel> GetSupplierById(int Id)
        {
            var SupplierById = await _context.Suppliers.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (SupplierById != null)
            {
                var newSupplier = new SupplierViewModel
                {
                    Id = SupplierById.Id,
                    Name = SupplierById.Name,
                    Address = SupplierById.Address,
                    PhoneNumber = SupplierById.PhoneNumber
                };
                return newSupplier;
            }
            return null;
        }

        public async Task<SuppliersPaging> GetListSuppliers(SupplierPagingRequest supplierPagingRequest)
        {
            var res = new List<SupplierViewModel>();
            var query = await _context.Suppliers.ToListAsync();
            res = query.Select(g => new SupplierViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Address = g.Address,
                PhoneNumber = g.PhoneNumber
            }).Skip(supplierPagingRequest.PageSize * (supplierPagingRequest.PageIndex - 1))
                               .Take(supplierPagingRequest.PageSize).ToList();
            var totalItem = query.Count();
            return new SuppliersPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddSupplier(SupplierAddModel model)
        {
            if (model != null)
            {
                var newSupplier = new Supplier
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                };
                await _context.AddAsync(newSupplier);
                
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSupplier(SupplierUpdateModel model)
        {
            if (model != null)
            {
                var oldSupplier = await _context.Suppliers.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (oldSupplier != null)
                {
                    oldSupplier.Id = model.Id;
                    oldSupplier.Name = model.Name;
                    oldSupplier.PhoneNumber = model.PhoneNumber;
                    oldSupplier.Address = model.Address;
                    _context.Suppliers.Update(oldSupplier);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSupplier(int Id)
        {
            var oldSupplier = await _context.Suppliers.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (oldSupplier != null)
            {
                _context.Suppliers.Remove(oldSupplier);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
