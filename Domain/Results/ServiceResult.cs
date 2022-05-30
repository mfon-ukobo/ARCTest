using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
	public class ServiceResult
	{
		public bool Succeeded { get; protected internal set; }
		public IList<string> Errors { get; protected internal set; }

		public static ServiceResult Success => new ServiceResult
		{
			Succeeded = true
		};

		public static ServiceResult Failure(IEnumerable<string> messages) => new ServiceResult
		{
			Succeeded = false,
			Errors = new List<string>(messages)
		};

		public static ServiceResult Failure(string message) => Failure(new string[] { message });
	}
}
