using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

	[Table("Customers")]
	public class Customer : DatedEntity<long, DateTimeOffset, DateTimeOffset>
	{
		public Guid UserId { get; set; }
		public long LocalGovernmentId { get; set; }
	}
}
