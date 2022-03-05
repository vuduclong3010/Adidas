using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
