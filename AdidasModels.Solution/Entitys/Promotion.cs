using AdidasModels.Solution.Enums;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public decimal? DiscountAmount { set; get; }
        public Status Status { set; get; }
        public List<Product> Products { get; set; }
    }
}
