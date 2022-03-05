using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class OrderViewModel
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
    }

    public class OrdersPaging
    {
        public List<OrderViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
