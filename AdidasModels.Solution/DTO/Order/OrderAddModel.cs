using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasModels.Solution.DTO
{
    public class OrderAddModel
    {
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
    }
}
