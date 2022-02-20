using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class ContactService : IContactService
    {
        private readonly AdidasDbContext _context;
        public ContactService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<ContactViewModel> GetContactById(int Id)
        {
            var ContactById = await _context.Contacts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ContactById != null)
            {
                var newContact = new ContactViewModel
                {
                    Id = ContactById.Id,
                    Name = ContactById.Name,
                    Email = ContactById.Email,
                    PhoneNumber = ContactById.PhoneNumber,
                    Message = ContactById.Message,
                    Status = ContactById.Status
                };
                return newContact;
            }
            return null;
        }

        public async Task<ContactsPaging> GetListContacts(ContactPagingRequest ContactPagingRequest)
        {
            var res = new List<ContactViewModel>();
            var query = await _context.Contacts.ToListAsync();
            res = query.Select(g => new ContactViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Email = g.Email,
                PhoneNumber = g.PhoneNumber,
                Status = g.Status,
                Message = g.Message
            }).Skip(ContactPagingRequest.PageSize * (ContactPagingRequest.PageIndex - 1))
                               .Take(ContactPagingRequest.PageSize).ToList();
            var totalItem = query.Count();
            return new ContactsPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> AddContact(ContactAddModel model)
        {
            if (model != null)
            {
                var newContact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Message= model.Message,
                    Status = model.Status,
                };
                await _context.AddAsync(newContact);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateContact(ContactUpdateModel model)
        {
            if (model != null)
            {
                var oldContact = await _context.Contacts.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (oldContact != null)
                {
                    oldContact.Id = model.Id;
                    oldContact.Name = model.Name;
                    oldContact.PhoneNumber = model.PhoneNumber;
                    oldContact.Email = model.Email;
                    oldContact.Message = model.Message;
                    oldContact.Status = model.Status;
                    _context.Contacts.Update(oldContact);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteContact(int Id)
        {
            var oldContact = await _context.Contacts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (oldContact != null)
            {
                _context.Contacts.Remove(oldContact);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
