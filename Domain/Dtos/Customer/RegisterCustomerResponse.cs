
using Domain.Enums;

namespace Domain.Dtos.Customer
{
	public class RegisterCustomerResponse
	{
		public RegistrationStatus Status { get; set; }
		public string Token { get; set; }
	}
}
