using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;
using Application.Providers;
using Application.Repositories;

using Domain.Entities;
using Domain.Pagination;
using Domain.QueryFilters;
using Domain.Results;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Managers
{
	internal class CustomerManager : UserManager<Customer>, ICustomerManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPhoneNumberTokenProvider _phoneNumberTokenProvider;

		private const string ConfirmPhoneNumberTokenPurpose = "PhoneNumberConfirmation";

		public CustomerManager(IUserStore<Customer> store,
			IOptions<IdentityOptions> optionsAccessor,
			IPasswordHasher<Customer> passwordHasher,
			IEnumerable<IUserValidator<Customer>> userValidators,
			IEnumerable<IPasswordValidator<Customer>> passwordValidators,
			ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors,
			IServiceProvider services,
			ILogger<UserManager<Customer>> logger,
			IUnitOfWork unitOfWork,
			IPhoneNumberTokenProvider phoneNumberTokenProvider) : base(store,
				optionsAccessor,
				passwordHasher,
				userValidators,
				passwordValidators,
				keyNormalizer,
				errors,
				services,
				logger)
		{
			_unitOfWork = unitOfWork;
			_phoneNumberTokenProvider = phoneNumberTokenProvider;
		}

		public override async Task<IdentityResult> CreateAsync(Customer user, string password)
		{
			return await base.CreateAsync(user, password);
		}

		public override async Task<Customer> FindByEmailAsync(string email)
		{
			return await base.FindByEmailAsync(email);
		}

		public override async Task<Customer> FindByIdAsync(string userId)
		{
			return await base.FindByIdAsync(userId);
		}

		public async Task<PagedList<Customer>> GetAsync(CustomerFilterParameters parameters)
		{
			var customers = Users;

			return await PagedList<Customer>.ToPagedListAsync(customers, parameters.PageNumber, parameters.PageSize);
		}

		public async Task<string> GeneratePhoneNumberConfirmationTokenAsync(Customer customer)
		{
			ArgumentNullException.ThrowIfNull(customer);

			var token = await _phoneNumberTokenProvider.GenerateAsync(ConfirmPhoneNumberTokenPurpose, this, customer);
			return token;
		}

		public async Task<ManagerResult> ValidatePhoneNumberConfirmationTokenAsync(Customer customer, string token)
		{
			ArgumentNullException.ThrowIfNull(customer);

			var result = await _phoneNumberTokenProvider.ValidateAsync(ConfirmPhoneNumberTokenPurpose, token, this, customer);

			if (!result)
			{
				return ManagerResult.Failure("Invalid Token");
			}

			customer.PhoneNumberConfirmed = true;
			customer.ModifiedAt = DateTimeOffset.Now;

			var updateResult = await UpdateAsync(customer);

			if (!updateResult.Succeeded)
			{
				return ManagerResult.Failure(updateResult.Errors.Select(x => x.Description));
			}

			return ManagerResult.Success;
		}
	}
}
