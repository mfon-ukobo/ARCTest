using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Domain.Dtos.State;
using Domain.Entities;

namespace Domain.Mapping
{
	public class StateMapper : Profile
	{
		public StateMapper()
		{
			CreateMap<CreateStateRequest, State>();
			CreateMap<State, CreateStateResponse>();
			CreateMap<State, GetStatesResponse>();
		}
	}
}
