using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Providers;

using Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Providers
{
	internal class PhoneNumberTokenProvider : PhoneNumberTokenProvider<Customer>, IPhoneNumberTokenProvider
	{
		public override Task<string> GenerateAsync(string purpose, UserManager<Customer> manager, Customer user)
		{
			return base.GenerateAsync(purpose, manager, user);
		}

		public override Task<bool> ValidateAsync(string purpose, string token, UserManager<Customer> manager, Customer user)
		{
			return base.ValidateAsync(purpose, token, manager, user);
		}
	}
}
