using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WemaClient.Contracts;
using WemaClient.Models;

namespace WemaClient.Services
{
	internal class ALATTechTestService : BaseService, IALATTechTestService
	{
		private const string PRIMARY_SUBSCRIPTION_KEY = "9ae993cd400343b192556832b58e772b";

		public ALATTechTestService(HttpClient httpClient) : base(httpClient)
		{
			httpClient.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER, PRIMARY_SUBSCRIPTION_KEY);
		}

		public async Task<ApiResponse<IEnumerable<Bank>>> GetBanks()
		{
			var uri = " https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks";
			var banksResponse = await GetAsync<ApiResponse<IEnumerable<Bank>>>(uri);

			return banksResponse;
		}
	}
}
