using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Domain.Dtos.LocalGovernment;
using Domain.Entities;

namespace Domain.Mapping
{
	public class LocalGovernmentMapper : Profile
	{
		public LocalGovernmentMapper()
		{
			CreateMap<LocalGovernment, GetLocalGovernmentsResponse>();
			CreateMap<LocalGovernment, CreateLocalGovernmentResponse>();
			CreateMap<CreateLocalGovernmentRequest, LocalGovernment>();
		}
	}
}
