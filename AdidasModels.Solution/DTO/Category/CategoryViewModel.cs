using AdidasModels.Solution.Enums;
using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public int SortOrder { set; get; }
        public Status IsShowOnHome { set; get; }
    }

    public class CategoriesPaging
    {
        public List<CategoryViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
