namespace Domain.Dtos.Customer
{
	public class GetCustomersResponse
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public long LocalGovernmentId { get; set; }
	}
}
