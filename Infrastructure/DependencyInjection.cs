using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Database;
using Application.Managers;
using Application.Repositories;

using Domain.Entities;
using Domain.Mapping;

using Infrastructure.Database;
using Infrastructure.Managers;
using Infrastructure.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddManagers();

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddAutoMapper(options =>
			{
				options.AddMaps(typeof(StateMapper).Assembly);
			});

			services.AddDbContext<ISQLContext, SQLContext>(options =>
			{
				var connectionString = configuration.GetConnectionString("DatabaseConnString");
				options.UseSqlServer(connectionString,
					x => x.MigrationsAssembly("Infrastructure"));
			});

			services.AddIdentity<AppUser, AppRole>()
				.AddEntityFrameworkStores<SQLContext>()
				.AddDefaultTokenProviders();
		}

		private static void AddManagers(this IServiceCollection services)
		{
			services.AddScoped<IUserManager, UserManager>();
			services.AddScoped<IStateManager, StateManager>();
			services.AddScoped<ILocalGovernmentManager, LocalGovernmentManager>();
		}
	}
}
