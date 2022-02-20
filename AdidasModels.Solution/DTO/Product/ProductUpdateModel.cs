using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int SupplierId { get; set; }
        public int TrademarkId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string SeoTitle { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string shoelace { get; set; }
        public string DeGiay { get; set; }
        public float TrongLuong { get; set; }
        public string KieuDang { get; set; }
        public List<ProductInCategoryAddModel> Categories { get; set; } = new List<ProductInCategoryAddModel>();
    }
}
