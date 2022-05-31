using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Pagination;
using Domain.QueryFilters;
using Domain.Results;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
	public interface ICustomerManager
	{
		Task<IdentityResult> CreateAsync(Customer user, string password);
		Task<Customer> FindByEmailAsync(string email);
		Task<Customer> FindByIdAsync(string userId);
		Task<string> GeneratePhoneNumberConfirmationTokenAsync(Customer customer);
		Task<PagedList<Customer>> GetAsync(CustomerFilterParameters parameters);
		Task<ManagerResult> ValidatePhoneNumberConfirmationTokenAsync(Customer customer, string token);
	}
}
