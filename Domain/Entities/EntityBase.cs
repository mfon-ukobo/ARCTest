using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class EntityBase<TKey>
	{
		public TKey Id { get; set; }
	}

	public class DatedEntity<TKey, TCreated> : EntityBase<TKey>
	{
		public TCreated CreatedAt { get; set; }
	}

	public class DatedEntity<TKey, TCreated, TModified> : DatedEntity<TKey, TCreated>
	{
		public TModified ModifiedAt { get; set; }
	}
}
