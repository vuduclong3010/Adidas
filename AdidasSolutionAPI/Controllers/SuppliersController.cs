using AdidasModels.Solution.DTO;
using AdidasSolutionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdidasSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("GetListSuppliers")]
        public async Task<SuppliersPaging> GetListSuppliers([FromQuery] SupplierPagingRequest supplierPagingRequest)
        {
            var rs = await _supplierService.GetListSuppliers(supplierPagingRequest);
            return rs;
        }

        [HttpGet("GetSupplierById")]
        public async Task<IActionResult> GetSupplierById(int Id)
        {
            var rs = await _supplierService.GetSupplierById(Id);
            if(rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Not Found Supplier");
        }

        [HttpPost("AddSupplier")]
        public async Task<bool> AddSupplier(SupplierAddModel model)
        {
            var rs = await _supplierService.AddSupplier(model);
            return rs;
        }

        [HttpPost("UpdateSupplier")]
        public async Task<bool> UpdateSupplier(SupplierUpdateModel model)
        {
            var rs = await _supplierService.UpdateSupplier(model);
            return rs;
        }

        [HttpPost("DeleteSupplier")]
        public async Task<bool> DeleteSupplier(int Id)
        {
            var rs = await _supplierService.DeleteSupplier(Id);
            return rs;
        }
    }
}
