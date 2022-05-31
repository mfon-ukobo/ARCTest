using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WemaClient.Models
{
	public class ApiResponse<T>
	{
		public T Result { get; init; }
		public string ErrorMessage { get; init; }
		public IEnumerable<string> ErrorMessages { get; init; }
		public bool HasError { get; init; }
		public DateTime TimeGenerated { get; init; }
	}
}
