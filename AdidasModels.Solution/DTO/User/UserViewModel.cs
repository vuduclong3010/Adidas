using AdidasModels.Solution.Enums;
using System;
using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public DateTime Dob { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Url { get; set; }
        public Status Status { get; set; }
    }

    public class UsersPaging
    {
        public List<UserViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
