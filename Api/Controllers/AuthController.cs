using Application.Managers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ICustomerManager _customerManager;

		public AuthController(ICustomerManager customerManager)
		{
			_customerManager = customerManager;
		}

		/// <summary>
		/// Get the phone number confirmation token
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpGet("verify-phone-number")]
		public async Task<IActionResult> VerifyPhoneNumber(string email)
		{
			var customer = await _customerManager.FindByEmailAsync(email);

			if (customer is null)
			{
				return BadRequest(new string[] { "Invalid Customer Email" });
			}

			var token = await _customerManager.GeneratePhoneNumberConfirmationTokenAsync(customer);
			return Ok(token);
		}


		/// <summary>
		/// Validate the phone number confirmation token
		/// </summary>
		/// <param name="email"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpPost("verify-phone-number")]
		public async Task<IActionResult> VerifyPhoneNumber(string email, string token)
		{
			var customer = await _customerManager.FindByEmailAsync(email);

			if (customer is null)
			{
				return BadRequest(new string[] { "Invalid Customer Email" });
			}

			var validationResult = await _customerManager.ValidatePhoneNumberConfirmationTokenAsync(customer, token);

			if (!validationResult.Succeeded)
			{
				return BadRequest(new string[] { "Invalid Token" });
			}

			return Accepted();
		}
	}
}
