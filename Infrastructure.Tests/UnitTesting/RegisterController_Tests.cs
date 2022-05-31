using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Controllers;

using Application.Managers;
using Application.Repositories;
using Application.Services;

using Domain.Dtos.Customer;
using Domain.Exceptions;

using Moq;

using Xunit;

namespace Api.Tests.UnitTesting
{
	public class RegisterController_Tests
	{
		Mock<ILocalGovernmentManager> mockLocalGovernmentManager = new Mock<ILocalGovernmentManager>();
		Mock<IRegistrationService> mockRegistrationService = new Mock<IRegistrationService>();

		[Fact]
		public async Task RegisterMember_LocalGovernmentDoesNotBelongToState_BadRequest()
		{
			string email = "coache@mailinator.com";
			string phoneNumber = "09032627957";
			string password = "Password@1234";
			long stateId = 1;
			long localGovernmentId = 2;

			var request = new RegisterCustomerRequest
			{
				Email = email,
				PhoneNumber = phoneNumber,
				Password = password,
				StateId = stateId,
				LocalGovernmentId = localGovernmentId
			};

			mockRegistrationService.Setup(x => x.RegisterCustomer(email, phoneNumber, password, stateId, localGovernmentId));

			var registerController = new RegisterController(mockRegistrationService.Object);

			var result = await registerController.RegisterMember(request);

			Assert.IsType<LocalGovernmentStateMismatchException>(result);
		}
	}
}
