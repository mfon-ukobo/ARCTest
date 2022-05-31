using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WemaClient.Contracts;
using WemaClient.Services;

namespace WemaClient
{
	public class WemaApiClient : IWemaApiClient
	{
		private readonly HttpClient _httpClient;

		public WemaApiClient(HttpClient httpClient)
		{
			httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
			_httpClient = httpClient;
		}

		public IALATTechTestService ALATTechTest => new ALATTechTestService(_httpClient);
	}
}
