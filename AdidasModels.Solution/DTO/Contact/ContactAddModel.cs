using AdidasModels.Solution.Enums;

namespace AdidasModels.Solution.DTO
{
    public class ContactAddModel
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
        public Status Status { set; get; }
    }
}
