using AdidasModels.Solution.Enums;
using System.Collections.Generic;

namespace AdidasModels.Solution.DTO
{
    public class ContactViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
        public Status Status { set; get; }
    }

    public class ContactsPaging
    {
        public List<ContactViewModel> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
