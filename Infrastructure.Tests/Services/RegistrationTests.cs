using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Repositories;
using Application.Services;

using Domain.Entities;
using Domain.Enums;

using Moq;

namespace Infrastructure.Tests.Services
{
	public class RegistrationTests
	{
		public void RegisterCustomer_WithValidCustomer_CreateCustomerResultSuccess()
		{
			// Arrange
			var customerId = Guid.NewGuid();
			var expectedStatus = RegistrationStatus.PhoneOTP;
			var stateId = 1;

			var state = new State
			{
				Id = stateId,
				Name = "Akwa Ibom"
			};

			var localGovernment = new LocalGovernment
			{
				StateId = stateId,
				Name = "Unsit Ubitm",
				Id = 1
			};

			var stateRepoMock = new Mock<IRepository<State>>();
			stateRepoMock.Setup(x => x.GetFirstAsync(y => y.Id == 1))
				.ReturnsAsync(state)
				.Verifiable();

			var localGovernmentRepoMock = new Mock<IRepository<LocalGovernment>>();
			localGovernmentRepoMock.Setup(x => x.GetFirstAsync(y => y.Id == 1))
				.ReturnsAsync(localGovernment)
				.Verifiable();

			var unitOfWorkMock = new Mock<IUnitOfWork>();
			unitOfWorkMock.Setup(uow => uow.LocalGovernment).Returns(localGovernmentRepoMock.Object);
			unitOfWorkMock.Setup(uow => uow.State).Returns(stateRepoMock.Object);

			/*var registrationService = new Mock<IRegistrationService>()
				.Setup(x => x.RegisterCustomer());*/
		}
	}
}
