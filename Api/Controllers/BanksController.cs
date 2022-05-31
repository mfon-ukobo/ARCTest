using Application.Managers;

using Domain.QueryFilters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WemaClient;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BanksController : ControllerBase
	{
		private readonly IBankManager _bankManager;

		public BanksController(IBankManager bankManager)
		{
			_bankManager = bankManager;
		}

		/// <summary>
		/// Get Banks
		/// </summary>
		/// <returns></returns>
		/// <response code="200">A paginated list of Banks</response>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] BankFilterParameters parameters)
		{
			var banks = await _bankManager.GetAsync(parameters);
			return Ok(banks);
		}
	}
}
