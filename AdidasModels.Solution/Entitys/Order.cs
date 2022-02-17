using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public int? Deleted { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
    }
}
