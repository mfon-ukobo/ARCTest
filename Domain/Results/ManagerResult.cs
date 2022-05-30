using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
	public class ManagerResult
	{
		public bool Succeeded { get; protected internal set; }
		public IList<string> Errors { get; protected internal set; }

		public static ManagerResult Success => new ManagerResult
		{
			Succeeded = true
		};

		public static ManagerResult Failure(IEnumerable<string> messages) => new ManagerResult
		{
			Succeeded = false,
			Errors = new List<string>(messages)
		};

		public static ManagerResult Failure(string message) => Failure(new string[] { message });
	}
}
