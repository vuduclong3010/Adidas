using AdidasModels.Solution.Entitys;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ViewCount { get; set; }
        public bool? IsFeatured { get; set; }
        public DateTime DateCreated { set; get; }
        public int SizeId { get; set; }
        public int SupplierId { get; set; }
        public int TrademarkId { get; set; }
        public int? PromotionId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string SeoTitle { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string shoelace { get; set; }
        public string DeGiay { get; set; }
        public float TrongLuong { get; set; }
        public string KieuDang { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public Size Size { get; set; }
        public Trademark Trademark { get; set; }
        public Supplier Supplier { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
