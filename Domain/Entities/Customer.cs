
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
	public class Customer : IdentityUser<Guid>
	{
		public Customer()
		{

		}

		public Customer(string email)
		{
			Email = email;
		}

		public long LocalGovernmentId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset ModifiedAt { get; set; }
	}
}
