using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using AdidasModels.Solution.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasSolutionService
{
    public class UserService : IUserService
    {
        private readonly AdidasDbContext _context;
        public UserService(AdidasDbContext context)
        {
            _context = context;
        }

        public async Task<int> LoginUser(LoginUserViewModel request)
        {
            if(request != null)
            {
                var oldEmailUser = await _context.AppUsers.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
                var oldPasswordUser = await _context.AppUsers.Where(x => x.Password == request.Password).FirstOrDefaultAsync();
                if (oldEmailUser != null && oldPasswordUser == null)
                {
                    return 0;
                }
                else if(oldEmailUser == null && oldPasswordUser != null)
                {
                    return 1;
                }
                else if(oldEmailUser != null && oldPasswordUser != null)
                {
                    return 2;
                }
            }
            return 3;
        }

        public async Task<UsersPaging> GetListUers(UserPagingRequest request)
        {
            var res = new List<UserViewModel>();
            var query = await _context.AppUsers.ToListAsync();
            if(request.PhoneNumber != null)
            {
                query = await _context.AppUsers.Where(x => x.PhoneNumber == request.PhoneNumber).ToListAsync();
            }
            res = query.Select(g => new UserViewModel
            {
                Id = g.Id,
                FullName = g.FirstName + " " + g.LastName,
                Address = g.Address,
                Gender = g.Gender,
                Dob = g.Dob,
                PhoneNumber = g.PhoneNumber,
                Email = g.Email,
                Password = g.Password,
                Role = g.Role,
                Url = g.Url,
                Status = g.Status == 0 ? Status.InActive : Status.Active,
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new UsersPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<bool> UpdateStatus(UserAddStatusModel model)
        {
            var oldUser = await _context.AppUsers.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (oldUser != null)
            {
                oldUser.Status = model.Status;
                _context.AppUsers.Update(oldUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
