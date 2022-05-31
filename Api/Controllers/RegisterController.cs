using Application.Services;

using Domain.Dtos.Customer;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IRegistrationService _registrationService;

		public RegisterController(IRegistrationService registrationService)
		{
			_registrationService = registrationService;
		}

		/// <summary>
		/// Register a new Customer
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost("customer")]
		public async Task<IActionResult> RegisterCustomer(RegisterCustomerRequest request)
		{
			var createUserResult = await _registrationService
				.RegisterCustomer(request.Email, request.PhoneNumber, request.Password, request.StateId, request.LocalGovernmentId);

			if (!createUserResult.Succeeded)
			{
				return BadRequest(createUserResult.Errors);
			}

			var response = new RegisterCustomerResponse
			{
				Status = createUserResult.Status,
				Token = createUserResult.Token
			};

			return Ok(response);
		}
	}
}
