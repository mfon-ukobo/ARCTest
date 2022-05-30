using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Customer
{
	public class CreateCustomerRequest
	{
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public long LocalGovernmentId { get; set; }
	}
}
