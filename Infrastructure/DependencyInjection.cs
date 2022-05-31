using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Database;
using Application.Managers;
using Application.Providers;
using Application.Repositories;
using Application.Services;

using Domain.Entities;
using Domain.Mapping;

using Infrastructure.Database;
using Infrastructure.Managers;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using Infrastructure.Services;

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
			services.AddDatabase(configuration);
			services.AddIdentity();
			services.AddManagers();
			services.AddServices();
			services.AddProviders();

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddAutoMapper(options =>
			{
				options.AddMaps(typeof(StateMapper).Assembly);
			});
		}

		private static void AddManagers(this IServiceCollection services)
		{
			services.AddScoped<ICustomerManager, CustomerManager>();
			services.AddScoped<IStateManager, StateManager>();
			services.AddScoped<ILocalGovernmentManager, LocalGovernmentManager>();
			services.AddScoped<IBankManager, BankManager>();
		}

		private static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IRegistrationService, RegistrationService>();
		}

		private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ISQLContext, SQLContext>(options =>
			{
				var connectionString = configuration.GetConnectionString("Default");
				options.UseSqlServer(connectionString,
					x => x.MigrationsAssembly("Infrastructure"));
			});
		}

		private static void AddIdentity(this IServiceCollection services)
		{
			services.AddIdentity<Customer, AppRole>(options =>
			{
				options.SignIn.RequireConfirmedPhoneNumber = true;
			})
			.AddEntityFrameworkStores<SQLContext>()
			.AddDefaultTokenProviders();
		}

		private static void AddProviders(this IServiceCollection services)
		{
			services.AddScoped<IPhoneNumberTokenProvider, PhoneNumberTokenProvider>();
		}
	}
}
