using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _ContactService;
        public ContactsController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet("GetListContacts")]
        public async Task<ContactsPaging> GetListContacts([FromQuery] ContactPagingRequest ContactPagingRequest)
        {
            var rs = await _ContactService.GetListContacts(ContactPagingRequest);
            return rs;
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetContactById(int Id)
        {
            var rs = await _ContactService.GetContactById(Id);
            if (rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Contact");
        }

        [HttpPost("AddContact")]
        public async Task<bool> AddContact(ContactAddModel model)
        {
            var rs = await _ContactService.AddContact(model);
            return rs;
        }

        [HttpPost("UpdateContact")]
        public async Task<bool> UpdateContact(ContactUpdateModel model)
        {
            var rs = await _ContactService.UpdateContact(model);
            return rs;
        }

        [HttpPost("DeleteContact")]
        public async Task<bool> DeleteContact(int Id)
        {
            var rs = await _ContactService.DeleteContact(Id);
            return rs;
        }
    }
}
