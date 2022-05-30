
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
	public class AppUser : IdentityUser<Guid>
	{
		public AppUser()
		{

		}

		public AppUser(string email)
		{
			Email = email;
		}
	}
}
