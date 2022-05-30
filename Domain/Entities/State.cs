using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	[Table("States")]
	public class State : DatedEntity<long, DateTimeOffset, DateTimeOffset>
	{
		public string Name { get; set; }
	}
}
