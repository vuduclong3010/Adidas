using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetListUsers")]
        public async Task<UsersPaging> GetListUsers([FromQuery] UserPagingRequest request)
        {
            var rs = await _userService.GetListUers(request);
            return rs;
        }


        [HttpGet("LoginUser")]
        public async Task<IActionResult> LoginUser([FromQuery] LoginUserViewModel request)
        {
            var rs = await _userService.LoginUser(request);
            if(rs == 0)
            {
                return BadRequest("Mời bạn nhập lại Password");
            }
            else if(rs == 1)
            {
                return BadRequest("Mời bạn nhập lại Email");
            }
            else if(rs == 3)
            {
                return BadRequest("Mời bạn nhập Email và Password");
            }    
            return Ok("Đăng nhập thành công");
        }


        [HttpPost("UpdateStatus")]
        public async Task<bool> UpdateStatus(UserAddStatusModel model)
        {
            return await _userService.UpdateStatus(model);
        }
    }
}
