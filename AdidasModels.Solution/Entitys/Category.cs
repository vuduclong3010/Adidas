using AdidasModels.Solution.Entities;
using AdidasModels.Solution.Enums;
using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public int SortOrder { set; get; }
        public Status IsShowOnHome { set; get; }

        public List<ProductInCategory> ProductInCategories { get; set; }

    }
}
