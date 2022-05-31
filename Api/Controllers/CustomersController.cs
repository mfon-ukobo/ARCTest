using Application.Managers;
using Application.Services;

using AutoMapper;

using Domain.Dtos.Customer;
using Domain.QueryFilters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerManager _customerManager;
		private readonly IMapper _mapper;

		public CustomersController(ICustomerManager customerManager, IMapper mapper)
		{
			_customerManager = customerManager;
			_mapper = mapper;
		}

		/// <summary>
		/// Get Paginated Customers
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		/// <response code="200">A paginated list of Customers</response>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] CustomerFilterParameters parameters)
		{
			var customers = await _customerManager.GetAsync(parameters);

			return Ok(_mapper.Map<IEnumerable<GetCustomersResponse>>(customers));
		}
	}
}
