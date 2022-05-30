using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	[Table("LocalGovernments")]
	public class LocalGovernment : DatedEntity<long, DateTimeOffset, DateTimeOffset>
	{
		public string Name { get; set; }
		public long StateId { get; set; }
	}
}
