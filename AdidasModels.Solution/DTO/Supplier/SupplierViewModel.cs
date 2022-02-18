using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    public class SuppliersPaging
    {
        public List<SupplierViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
