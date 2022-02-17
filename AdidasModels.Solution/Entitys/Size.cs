namespace AdidasModels.Solution.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeDes { get; set; }
        public string Detail { get; set; }
        public Product Product { get; set; }
    }
}
