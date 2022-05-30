using Application.Managers;

using Domain.Dtos.Customer;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerManager _customerManager;

		public CustomersController(ICustomerManager customerManager)
		{
			_customerManager = customerManager;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCustomerRequest request)
		{
			var createUserResult = await _customerManager
				.CreateAsync(request.Email, request.PhoneNumber, request.LocalGovernmentId, request.Password);

			if (!createUserResult.Succeeded)
			{
				return BadRequest(createUserResult.Errors);
			}

			return Ok();
		}
	}
}
