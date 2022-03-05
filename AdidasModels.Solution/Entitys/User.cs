using AdidasModels.Solution.Enums;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public DateTime Dob { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Url { get; set; }

        public Status Status { get; set; }

        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }
    }
}
