using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasModels.Solution.DTO
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ViewCount { get; set; }
        public bool? IsFeatured { get; set; }
        public DateTime DateCreated { set; get; }
        public string SizeName { get; set; }
        public string SupplierName { get; set; }
        public string TrademarkName { get; set; }
        public string? PromotionName { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string SeoTitle { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string shoelace { get; set; }
        public string DeGiay { get; set; }
        public float TrongLuong { get; set; }
        public string KieuDang { get; set; }
    }

    public class ProductsPaging
    {
        public List<ProductViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
