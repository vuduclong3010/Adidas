using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Trademark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Despripation { get; set; }
        public List<Product> Products { get; set; }
    }
}
