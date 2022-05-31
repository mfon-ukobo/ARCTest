using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;

using Domain.Pagination;
using Domain.QueryFilters;

using WemaClient;
using WemaClient.Models;

namespace Infrastructure.Managers
{
	internal class BankManager : IBankManager
	{
		private readonly IWemaApiClient _wemaClient;

		public BankManager(IWemaApiClient wemaClient)
		{
			_wemaClient = wemaClient;
		}

		public async Task<PagedList<Bank>> GetAsync(BankFilterParameters parameters)
		{
			var banks = await _wemaClient.ALATTechTest.GetBanks();
			return await PagedList<Bank>.ToPagedListAsync(banks.Result.AsQueryable(), parameters.PageNumber, parameters.PageSize);
		}
	}
}
