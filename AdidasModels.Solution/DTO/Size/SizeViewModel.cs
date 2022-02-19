using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class SizeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeDes { get; set; }
        public string Detail { get; set; }
    }

    public class SizesPaging
    {
        public List<SizeViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
