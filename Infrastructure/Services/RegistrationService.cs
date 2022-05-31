using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;
using Application.Services;

using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Results;

namespace Infrastructure.Services
{
	internal class RegistrationService : IRegistrationService
	{
		private readonly ICustomerManager _customerManager;
		private readonly IStateManager _stateManager;
		private readonly ILocalGovernmentManager _localGovernmentManager;

		public RegistrationService(ICustomerManager customerManager, 
			IStateManager stateManager, 
			ILocalGovernmentManager localGovernmentManager)
		{
			_customerManager = customerManager;
			_stateManager = stateManager;
			_localGovernmentManager = localGovernmentManager;
		}

		public async Task<CustomerRegistrationResult> RegisterCustomer(string email, 
			string phoneNumber, 
			string password, 
			long stateId, 
			long localGovernmentId)
		{
			// validate state & localgovernment
			var localGovernment = await _localGovernmentManager.FindByIdAsync(localGovernmentId);
			if (localGovernment is null)
			{
				return CustomerRegistrationResult.Failure("Invalid Local Government Area");
			}

			var localGovernmentState = await _localGovernmentManager.GetStateAsync(localGovernment);
			if (localGovernmentState is null)
			{
				throw new InvalidOperationException("The Local Government does not have a state?");
			}

			if (localGovernmentState.Id != stateId)
			{
				return CustomerRegistrationResult.Failure("The Local Government does not belong to the State");
			}

			var duplicateCustomer = await _customerManager.FindByEmailAsync(email);
			if (duplicateCustomer is not null)
			{
				return CustomerRegistrationResult.Failure("Duplicate customer");
			};

			var customer = new Customer
			{
				Email = email,
				UserName = email,
				PhoneNumber = phoneNumber,
				LocalGovernmentId = localGovernmentId,
				CreatedAt = DateTimeOffset.Now,
				ModifiedAt = DateTimeOffset.Now
			};

			try
			{
				var createUserResult = await _customerManager.CreateAsync(customer, password);

				if (!createUserResult.Succeeded)
				{
					return CustomerRegistrationResult.Failure(createUserResult.Errors.Select(x => x.Description));
				}

				var phoneConfirmationToken = await _customerManager.GeneratePhoneNumberConfirmationTokenAsync(customer);

				return CustomerRegistrationResult.Success(RegistrationStatus.PhoneOTP, phoneConfirmationToken);
			}
			catch (Exception)
			{
				// TODO: Log error
				throw;
			}
		}
	}
}
