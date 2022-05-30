using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Results;

namespace Application.Managers
{
	public interface ICustomerManager
	{
		Task<ManagerResult> CreateAsync(string email, string phoneNumber, long localGovernmentId, string password);
	}
}
