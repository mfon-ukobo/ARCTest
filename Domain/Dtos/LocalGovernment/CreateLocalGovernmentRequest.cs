using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.LocalGovernment
{
	public class CreateLocalGovernmentRequest
	{
		public string Name { get; set; }
		public long StateId { get; set; }
	}
}
