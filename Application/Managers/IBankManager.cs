using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Pagination;
using Domain.QueryFilters;

using WemaClient.Models;

namespace Application.Managers
{
	public interface IBankManager
	{
		Task<PagedList<Bank>> GetAsync(BankFilterParameters parameters);
	}
}
