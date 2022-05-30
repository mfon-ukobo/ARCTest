using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Pagination;
using Domain.QueryFilters;
using Domain.Results;

namespace Application.Managers
{
	public interface ILocalGovernmentManager
	{
		Task<ManagerResult> CreateAsync(LocalGovernment localGovernment);
		Task<PagedList<LocalGovernment>> GetAsync(LocalGovernmentFilterParameters parameters);
	}
}
