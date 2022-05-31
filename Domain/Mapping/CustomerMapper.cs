using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Domain.Dtos.Customer;
using Domain.Entities;

namespace Domain.Mapping
{
	public class CustomerMapper : Profile
	{
		public CustomerMapper()
		{
			CreateMap<Customer, GetCustomersResponse>();
		}
	}
}
