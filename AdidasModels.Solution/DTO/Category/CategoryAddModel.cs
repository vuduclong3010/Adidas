namespace AdidasModels.Solution.DTO
{
    public class CategoryAddModel
    {
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public int SortOrder { set; get; }
        public int? ParentId { set; get; }
    }
}
