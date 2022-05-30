using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;
using Application.Repositories;

using Domain.Entities;
using Domain.Results;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Managers
{
	internal class CustomerManager : ICustomerManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserManager _userManager;

		public CustomerManager(IUnitOfWork unitOfWork, IUserManager userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public async Task<ManagerResult> CreateAsync(string email, string phoneNumber, long localGovernmentId, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);

			if (user is not null && await IsDuplicateCustomer(user))
			{
				return ManagerResult.Failure("Duplicate customer");
			};

			if (user is null)
			{
				user = new AppUser(email)
				{
					PhoneNumber = phoneNumber
				};
			}

			var customer = new Customer
			{
				UserId = user.Id,
				LocalGovernmentId = localGovernmentId,
				CreatedAt = DateTimeOffset.Now,
				ModifiedAt = DateTimeOffset.Now,
			};

			try
			{
				var createUserResult = await _userManager.CreateAsync(user, password);

				if (!createUserResult.Succeeded)
				{
					return ManagerResult.Failure(createUserResult.Errors.Select(x => x.Description));
				}

				_unitOfWork.Customer.Add(customer);
				await _unitOfWork.SaveAsync();

				return ManagerResult.Success;
			}
			catch (Exception)
			{
				// TODO: Log error
				throw;
			}


		}

		private async Task<bool> IsDuplicateCustomer(AppUser user)
		{
			var customer = await _unitOfWork
				.Customer
				.Entities
				.FirstOrDefaultAsync(x => x.UserId == user.Id);

			return customer is not null;
		}
	}
}
