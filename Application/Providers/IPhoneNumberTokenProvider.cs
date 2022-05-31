using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace Application.Providers
{
	public interface IPhoneNumberTokenProvider
	{
		Task<string> GenerateAsync(string purpose, UserManager<Customer> manager, Customer user);
		Task<bool> ValidateAsync(string purpose, string token, UserManager<Customer> manager, Customer user);
	}
}
