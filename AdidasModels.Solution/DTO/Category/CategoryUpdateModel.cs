using AdidasModels.Solution.Enums;

namespace AdidasModels.Solution.DTO
{
    public class CategoryUpdateModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public int SortOrder { set; get; }
        public Status IsShowOnHome { set; get; }
    }
}
