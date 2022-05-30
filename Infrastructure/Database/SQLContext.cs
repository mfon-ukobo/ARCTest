using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Database;

using Domain.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
	internal class SQLContext : IdentityDbContext<AppUser, AppRole, Guid>, ISQLContext
	{
		public SQLContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Customer> Customers => Set<Customer>();
		public DbSet<State> States => Set<State>();
		public DbSet<LocalGovernment> LocalGovernments => Set<LocalGovernment>();

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await base.SaveChangesAsync(cancellationToken);
		}

		public override DbSet<TEntity> Set<TEntity>()
		{
			return base.Set<TEntity>();
		}
	}
}
