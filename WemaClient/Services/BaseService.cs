using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WemaClient.Services
{
	internal class BaseService
	{
		protected const string AUTHORIZATION_HEADER = "Ocp-Apim-Subscription-Key";
		private readonly HttpClient _httpClient;

		public BaseService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		protected internal async Task<T> GetAsync<T>(string uri)
		{
			var response = await _httpClient.GetAsync(uri);
			var content = await response.Content.ReadAsStringAsync();
			var deserializedContent = JsonConvert.DeserializeObject<T>(content);

			return deserializedContent;
		}
	}
}
