using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;
using Application.Services;

using Domain.Results;

namespace Infrastructure.Services
{
	internal class RegistrationService : IRegistrationService
	{
		private readonly IUserManager _userManager;

		public RegistrationService(IUserManager userManager)
		{
			_userManager = userManager;
		}
	}
}
