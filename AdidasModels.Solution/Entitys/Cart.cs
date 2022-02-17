using AdidasModels.Solution.Entities;
using System;

namespace AdidasModels.Solution.Entitys
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public string SizeShoe { get; set; }
        public decimal Price { set; get; }

        public int UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }

        public User User { get; set; }
    }
}
