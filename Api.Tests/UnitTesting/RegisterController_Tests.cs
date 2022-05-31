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
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Pagination;
using Domain.QueryFilters;
using Domain.Results;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Tests.UnitTesting
{
	public class RegisterController_Tests
	{
		Mock<ILocalGovernmentManager> mockLocalGovernmentManager = new Mock<ILocalGovernmentManager>();
		Mock<IStateManager> mockStateManager = new Mock<IStateManager>();
		Mock<ICustomerManager> mockCustomerManager = new Mock<ICustomerManager>();
		Mock<IRegistrationService> mockRegistrationService = new Mock<IRegistrationService>();

		public RegisterController_Tests()
		{
			Setup();
		}

		[Fact]
		public async Task RegisterMember_IsValid_OkObjectResult()
		{
			var requestModel = GetValidCustomer();


			mockRegistrationService
				.Setup(x => x.RegisterCustomer(
					requestModel.Email,
					requestModel.PhoneNumber,
					requestModel.Password,
					requestModel.StateId,
					requestModel.LocalGovernmentId))
				.ReturnsAsync(CustomerRegistrationResult.Success(RegistrationStatus.PhoneOTP, "123456"));

			var registerController = new RegisterController(mockRegistrationService.Object);

			var actionResult = await registerController.RegisterCustomer(requestModel);
			var okObjectResult = actionResult as OkObjectResult;
			var responseModel = okObjectResult.Value as RegisterCustomerResponse;

			Assert.NotNull(okObjectResult);
			Assert.NotNull(responseModel);
			Assert.Equal("123456", responseModel.Token);
			Assert.Equal(RegistrationStatus.PhoneOTP, responseModel.Status);
		}

		[Fact]
		public async Task RegisterMember_LocalGovernmentNotInState_BadRequestObjectResult()
		{
			// Arrange
			var customer = GetCustomer_WithLocalGovernmentNotInState();

			mockRegistrationService
				.Setup(x => x.RegisterCustomer(
					customer.Email,
					customer.PhoneNumber,
					customer.Password,
					customer.StateId,
					customer.LocalGovernmentId))
				.ReturnsAsync(CustomerRegistrationResult.Failure(""))
				.Verifiable();
			
			var registerController = new RegisterController(mockRegistrationService.Object);


			// Act
			var actionResult = await registerController.RegisterCustomer(customer);

			mockRegistrationService.Verify(x => x.RegisterCustomer(customer.Email,
					customer.PhoneNumber,
					customer.Password,
					customer.StateId,
					customer.LocalGovernmentId));


			var badRequestresult = actionResult as BadRequestObjectResult;

			// Assert
			Assert.IsType<BadRequestObjectResult>(actionResult);

			var responseModel = badRequestresult?.Value as List<string>;
			Assert.NotNull(responseModel);
			Assert.IsType<List<string>>(responseModel);
		}

		[Fact]
		public async Task RegisterMember_EmailNotValid_BadRequestObjectResult()
		{
			var customer = GetCustomer_WithInvalidEmail();

			mockRegistrationService
				.Setup(x => x.RegisterCustomer(
					customer.Email,
					customer.PhoneNumber,
					customer.Password,
					customer.StateId,
					customer.LocalGovernmentId))
				.ReturnsAsync(CustomerRegistrationResult.Failure(""))
				.Verifiable();

			var registerController = new RegisterController(mockRegistrationService.Object);


			// Act
			var actionResult = await registerController.RegisterCustomer(customer);


			// Assert
			Assert.NotNull(actionResult);

			mockRegistrationService.Verify(x => x.RegisterCustomer(customer.Email,
					customer.PhoneNumber,
					customer.Password,
					customer.StateId,
					customer.LocalGovernmentId));

			var badRequestresult = actionResult as BadRequestObjectResult;
			Assert.NotNull(badRequestresult);

			var responseModel = badRequestresult?.Value as List<string>;
			Assert.NotNull(responseModel);
			Assert.IsType<List<string>>(responseModel);
		}

		private void Setup()
		{
			var localGovernmentFilterParameters = new LocalGovernmentFilterParameters();
			mockLocalGovernmentManager
				.Setup(x => x.GetAsync(localGovernmentFilterParameters))
				.ReturnsAsync(
					PagedList<LocalGovernment>.ToPagedList(
						GetLocalGovernments(),
						localGovernmentFilterParameters.PageNumber,
						localGovernmentFilterParameters.PageSize)
					);

			var stateFilterParameters = new StateFilterParameters();
			mockStateManager.Setup(x => x.GetAsync(stateFilterParameters))
				.ReturnsAsync(PagedList<State>.ToPagedList(
					GetStates(),
					stateFilterParameters.PageNumber,
					stateFilterParameters.PageSize));
		}

		private IEnumerable<State> GetStates()
		{
			var states = new List<State>();
			states.Add(new State { Id = 1, Name = "Akwa Ibom" });
			states.Add(new State { Id = 2, Name = "Lagos" });

			return states;
		}

		private IEnumerable<LocalGovernment> GetLocalGovernments()
		{
			var localGovernmentAreas = new List<LocalGovernment>();

			localGovernmentAreas.Add(new LocalGovernment { Id = 1, Name = "Nsit Ubium", StateId = 1 });
			localGovernmentAreas.Add(new LocalGovernment { Id = 2, Name = "Oshodi Isolo", StateId = 2 });
			localGovernmentAreas.Add(new LocalGovernment { Id = 3, Name = "Ikeja", StateId = 2 });

			return localGovernmentAreas;
		}

		private RegisterCustomerRequest GetValidCustomer()
		{
			return new RegisterCustomerRequest
			{
				Email = "coache@mailinator.com",
				Password = "Password@1234",
				PhoneNumber = "09032627957",
				LocalGovernmentId = 1,
				StateId = 1
			};
		}

		private RegisterCustomerRequest GetCustomer_WithLocalGovernmentNotInState()
		{
			return new RegisterCustomerRequest
			{
				Email = "coache@mailinator.com",
				Password = "Password@1234",
				PhoneNumber = "09032627957",
				LocalGovernmentId = 2,
				StateId = 1
			};
		}

		private RegisterCustomerRequest GetCustomer_WithInvalidEmail()
		{
			return new RegisterCustomerRequest
			{
				Email = "coache.com",
				Password = "Password@1234",
				PhoneNumber = "09032627957",
				LocalGovernmentId = 1,
				StateId = 1
			};
		}
	}
}
