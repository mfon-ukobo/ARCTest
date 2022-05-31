using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WemaClient.Models
{
	public class Bank
	{
		[JsonProperty("bankName")]
		public string Name { get; set; }

		[JsonProperty("bankCode")]
		public string Code { get; set; }
	}
}
