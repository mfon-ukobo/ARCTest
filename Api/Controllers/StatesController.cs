﻿using Application.Managers;

using AutoMapper;

using Domain.Dtos.State;
using Domain.Entities;
using Domain.QueryFilters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatesController : ControllerBase
	{
		private readonly IStateManager _stateManager;
		private readonly IMapper _mapper;

		public StatesController(IStateManager stateManager, IMapper mapper)
		{
			_stateManager = stateManager;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateStateRequest request)
		{
			var state = _mapper.Map<State>(request);

			var result = await _stateManager.CreateAsync(state);

			if (!result.Succeeded)
			{
				return BadRequest(result.Errors);
			}

			return Ok(_mapper.Map<CreateStateResponse>(state));
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] StateFilterParameters parameters)
		{
			var states = await _stateManager.GetAsync(parameters);

			return Ok(_mapper.Map<IEnumerable<State>>(states));
		}
	}
}
