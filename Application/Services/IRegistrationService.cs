using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Results;

namespace Application.Services
{
	public interface IRegistrationService
	{
		Task<CustomerRegistrationResult> RegisterCustomer(string email, string phoneNumber, string password, long stateId, long localGovernmentId);
	}
}
