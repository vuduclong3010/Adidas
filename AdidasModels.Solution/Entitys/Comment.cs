using AdidasModels.Solution.Enums;
using System;

namespace AdidasModels.Solution.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
    }
}
