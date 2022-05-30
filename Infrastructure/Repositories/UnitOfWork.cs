using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Database;
using Application.Repositories;

using Domain.Entities;

namespace Infrastructure.Repositories
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly ISQLContext _context;

		public UnitOfWork(ISQLContext context)
		{
			_context = context;
		}

		public async Task SaveAsync(CancellationToken cancellationToken = default)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public IRepository<Customer> Customer => new Repository<Customer>(_context);
		public IRepository<State> State => new Repository<State>(_context);
		public IRepository<LocalGovernment> LocalGovernment => new Repository<LocalGovernment>(_context);
	}
}
