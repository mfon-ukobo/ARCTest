using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Repositories
{
	public interface IUnitOfWork
	{
		IRepository<Customer> Customer { get; }
		IRepository<State> State { get; }
		IRepository<LocalGovernment> LocalGovernment { get; }

		Task SaveAsync(CancellationToken cancellationToken = default);
	}
}
