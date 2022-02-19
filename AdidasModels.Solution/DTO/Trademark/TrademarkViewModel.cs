using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class TrademarkViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Despripation { get; set; }
    }

    public class TrademarkrsPaging
    {
        public List<TrademarkViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
