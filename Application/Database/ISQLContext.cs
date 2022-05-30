using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Application.Database
{
	public interface ISQLContext
	{
		DbSet<Customer> Customers { get; }
		DbSet<State> States { get; }
		DbSet<LocalGovernment> LocalGovernments { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
	}
}
