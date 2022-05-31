using Application.Managers;

using AutoMapper;

using Domain.Dtos.LocalGovernment;
using Domain.Entities;
using Domain.QueryFilters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocalGovernmentsController : ControllerBase
	{
		private readonly ILocalGovernmentManager _localGovernmentManager;
		private readonly IMapper _mapper;

		public LocalGovernmentsController(ILocalGovernmentManager localGovernmentManager, IMapper mapper)
		{
			_localGovernmentManager = localGovernmentManager;
			_mapper = mapper;
		}

		/// <summary>
		/// Create Local Government
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <response code="200">The newly created Local Government</response>
		[HttpPost]
		public async Task<IActionResult> Create(CreateLocalGovernmentRequest request)
		{
			var localGovernment = _mapper.Map<LocalGovernment>(request);

			var result = await _localGovernmentManager.CreateAsync(localGovernment);

			if (!result.Succeeded)
			{
				return BadRequest(result.Errors);
			}

			return Ok(_mapper.Map<CreateLocalGovernmentResponse>(localGovernment));
		}

		/// <summary>
		/// Get Paginated Local Governments
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		/// <response code="200">A paginated list of Local Governments</response>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] LocalGovernmentFilterParameters parameters)
		{
			var localGovernments = await _localGovernmentManager.GetAsync(parameters);

			return Ok(_mapper.Map<IEnumerable<GetLocalGovernmentsResponse>>(localGovernments));
		}
	}
}
