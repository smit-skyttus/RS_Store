using InfiGrowth.Models.Enum;

namespace InfiGrowth.Models.Dto
{
    public class UpdateCustomerRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public Guid ClientID { get; set; }
        //public Guid ProjectId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public Guid OrganizationId { get; set; }
        // public AuthenticationType AuthenticationType { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public List<Guid> ProjectIds { get; set; } = new();
    }
}
