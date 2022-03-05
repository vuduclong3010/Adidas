﻿using AdidasModels.Solution.Enums;
using System;

namespace AdidasModels.Solution.DTO
{
    public class PromotionUpdateModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public decimal? DiscountAmount { set; get; }
        public Status Status { set; get; }
    }
}
